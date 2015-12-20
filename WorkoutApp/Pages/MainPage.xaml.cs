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
    using System.Linq;

    public sealed partial class MainPage : Page
    {
        private string curentView = "Home";
        private Timer timer;

        public MainPage()
        {
            this.InitializeComponent();
            this.InitAsync();
            this.DataContext = new MainPageViewModel();
//this.RefreshPage();



            this.AppNav.OnNavigateParentReadyForHome += AppNav_OnNavigateParentReadyForHome;
            this.AppNav.OnNavigateParentReadyForMotivation += AppNav_OnNavigateParentReadyForMotivation;
            this.AppNav.OnNavigateParentReadyForAddWorkout += AppNav_OnNavigateParentReadyForAddWorkout;
            this.AppNav.OnNavigateParentReadyForStatistics += AppNav_OnNavigateParentReadyForStatistics;
            this.AppNav.OnNavigateParentReadyForSettings += AppNav_OnNavigateParentReadyForSettings;
        }

        private void AppNav_OnNavigateParentReadyForHome(object source, EventArgs e)
        {
            if (curentView != "Home")
            {
                Frame.Navigate(typeof(MainPage));
            }
            else
            {
                //TODO: Get new inspiration tip.
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
                //TODO: This is just to test that the async method works. Remove at a later point.
                var tips = new GetRandomInspirationTip();
                string tip = await tips.GetInspirationTipAsync();
                this.InspirationTip.Text = tip;
                this.InspirationTip.Opacity = 1;
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


        // Data Base methods

        private async void RefreshPage()
        {
            var mainPage = this.DataContext as MainPageViewModel;
            mainPage.WeekWorkouts.AddRange(await GetAllDailyWorkoutsAsync());
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

    }
}