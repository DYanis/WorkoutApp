namespace WorkoutApp.Pages
{
    using Mvvm.ViewModels;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using WorkoutApp.Helpers.Inspirations;
    using Pages;
    using System.Threading;
    using System;
    using Mvvm;

    public sealed partial class MainPage : Page
    {
        private Timer timer;

        public MainPage()
        {
            this.InitializeComponent();
            var mainPageViewModel = new MainPageViewModel();
            mainPageViewModel.WeekWorkouts.Add(new DailyWorkout
            {
                Day = DayOfWeek.Friday,
                Type = WorkoutType.CrossFit,
                Start = new TimeSpan(5, 24, 33)
            });

            mainPageViewModel.WeekWorkouts.Add(new DailyWorkout
            {
                Day = DayOfWeek.Sunday,
                Type = WorkoutType.Fitness,
                Start = new TimeSpan(13, 24, 33)
            });

            mainPageViewModel.WeekWorkouts.Add(new DailyWorkout
            {
                Day = DayOfWeek.Sunday,
                Type = WorkoutType.Fitness,
                Start = new TimeSpan(13, 24, 33)
            });

            mainPageViewModel.WeekWorkouts.Add(new DailyWorkout
            {
                Day = DayOfWeek.Sunday,
                Type = WorkoutType.Fitness,
                Start = new TimeSpan(13, 24, 33)
            });

            mainPageViewModel.WeekWorkouts.Add(new DailyWorkout
            {
                Day = DayOfWeek.Sunday,
                Type = WorkoutType.Fitness,
                Start = new TimeSpan(13, 24, 33)
            });

            mainPageViewModel.WeekWorkouts.Add(new DailyWorkout
            {
                Day = DayOfWeek.Sunday,
                Type = WorkoutType.Fitness,
                Start = new TimeSpan(13, 24, 33)
            });

            mainPageViewModel.WeekWorkouts.Add(new DailyWorkout
            {
                Day = DayOfWeek.Sunday,
                Type = WorkoutType.Fitness,
                Start = new TimeSpan(13, 24, 33)
            });


            this.DataContext = mainPageViewModel;
        }

        //private void InitializeInspirationImageTimer()
        //{
        //    timer = new Timer(timerCallback, null, TimeSpan.FromMinutes(1).Milliseconds, Timeout.Infinite);
        //}

        //private async void timerCallback(object state)
        //{
        //    // do some work not connected with UI

        //    await Window.Current.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
        //        () => 
        //        {
        //            int i = 1 + 1;
        //        });
        //}

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
    }
}