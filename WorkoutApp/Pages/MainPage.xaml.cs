namespace WorkoutApp.Pages
{
    using Mvvm.ViewModels;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using WorkoutApp.Helpers.Inspirations;
    using System.Threading;
    using System;
    using Mvvm;
    using SQLite.Net.Async;
    using System.IO;
    using Windows.Storage;
    using SQLite.Net;
    using SQLite.Net.Platform.WinRT;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Helpers;
    using Windows.ApplicationModel;
    using Windows.UI.Xaml.Input;

    public sealed partial class MainPage : Page
    {
        private string curentView = "Home";
        private AssetsHelper assetsHelper;
        private Timer timer;

        public MainPage()
        {
            this.InitializeComponent();
            this.InitAsync();
            this.DataContext = new MainPageViewModel();
            this.RefreshPage();

            this.AppNav.OnNavigateParentReadyForHome += AppNav_OnNavigateParentReadyForHome;
            this.AppNav.OnNavigateParentReadyForMotivation += AppNav_OnNavigateParentReadyForMotivation;
            this.AppNav.OnNavigateParentReadyForAddWorkout += AppNav_OnNavigateParentReadyForAddWorkout;
            this.AppNav.OnNavigateParentReadyForStatistics += AppNav_OnNavigateParentReadyForStatistics;
            this.AppNav.OnNavigateParentReadyForSettings += AppNav_OnNavigateParentReadyForSettings;

            Application.Current.Resuming += new EventHandler<Object>(App_Resuming);
            Application.Current.Suspending += new SuspendingEventHandler(App_Suspending);

            this.assetsHelper = new AssetsHelper();
            this.assetsHelper.GetTipsData();
        }

        private void App_Suspending(object sender, SuspendingEventArgs e)
        {
            ToastHelper.PopToast("Workout", "Suspend");
        }

        private void App_Resuming(object sender, object e)
        {
            ToastHelper.PopToast("Workout", "Resume/Start");
        }

        private async void AppNav_OnNavigateParentReadyForHome(object source, EventArgs e)
        {
            if (curentView != "Home")
            {
                Frame.Navigate(typeof(MainPage));
            }
            else
            {
                var tips = new GetRandomInspirationTip();
                string tip = await tips.GetInspirationTipAsync();
                this.InspirationTip.Text = tip;
                ToastHelper.PopToast("Motivational tip", tip);
            }
        }

        private void AppNav_OnNavigateParentReadyForMotivation(object source, EventArgs e)
        {
            if (curentView != "Motivation")
            {
                Frame.Navigate(typeof(MotivationPage));
            }
        }

        private void AppNav_OnNavigateParentReadyForAddWorkout(object source, EventArgs e)
        {
            if (curentView != "AddWorkout")
            {
                Frame.Navigate(typeof(AddWorkoutPage));
            }
        }

        private void AppNav_OnNavigateParentReadyForStatistics(object source, EventArgs e)
        {
            if (curentView != "Statistics")
            {
                Frame.Navigate(typeof(StatisticsPage));
            }
        }

        private void AppNav_OnNavigateParentReadyForSettings(object source, EventArgs e)
        {
            if (curentView != "Settings")
            {
                Frame.Navigate(typeof(SettingsPage));
            }
        }

        private async void PopulateInspirationTipAsync(object sender, RoutedEventArgs e)
        {
            {
                var tips = new GetRandomInspirationTip();
                string tip = await tips.GetInspirationTipAsync();
                this.InspirationTip.Text = tip;
            }
        }

        private void OnGoToSettingsPageClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SettingsPage));
        }

        private void OnGoToMotivationPageClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MotivationPage));
        }

        private void OnAddWorkoutClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddWorkoutPage));
        }

        private void OnGoToWorkoutInfoPageDoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(WorkoutInfoPage), (sender as Grid));
        }

        //TODO: Data Base methods
        private async void RefreshPage()
        {
            var mainPage = this.DataContext as MainPageViewModel;
            var workouts = await GetAllDailyWorkoutsAsync();
          
            foreach (var workout in workouts)
            {
                mainPage.WeekWorkouts.Add(workout);
            }
        }

        private async void InitAsync()
        {
            var connection = this.GetDbConnectionAsync();
            await connection.CreateTableAsync<DailyWorkout>();
        }

        private SQLiteAsyncConnection GetDbConnectionAsync()
        {
            var dbFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "db.sqlite");
            
            var connectionFactory =
                new Func<SQLiteConnectionWithLock>(
                    () =>
                    new SQLiteConnectionWithLock(
                        new SQLitePlatformWinRT(),
                        new SQLiteConnectionString(dbFilePath, storeDateTimeAsTicks: false)));

            var asyncConnection = new SQLiteAsyncConnection(connectionFactory);

            return asyncConnection;
        }

        private async Task<List<DailyWorkout>> GetAllDailyWorkoutsAsync()
        {
            var connection = this.GetDbConnectionAsync();
            var result = await connection.Table<DailyWorkout>().ToListAsync();
            return result;
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as AppBarButton;
            var workout = button.DataContext as DailyWorkout;

            await DeleteDailyWorkoutAsync(workout);
            (this.DataContext as MainPageViewModel).WeekWorkouts.Remove(workout);
        }

           private async Task<int> DeleteDailyWorkoutAsync(DailyWorkout workout)
           {
               var connection = this.GetDbConnectionAsync();
        
               var query = await connection.Table<DailyWorkout>().Where(x => x.ID == workout.ID).FirstAsync();
               var result = await connection.DeleteAsync(query);
               var count = await connection.Table<DailyWorkout>().CountAsync();
        
               return result;
           }
    }     
}