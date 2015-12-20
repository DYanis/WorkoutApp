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
        private string curentView = "Home";
        private Timer timer;

        public MainPage()
        {
            this.InitializeComponent();
            var mainPageViewModel = new MainPageViewModel();

            this.AppNav.OnNavigateParentReadyForHome += AppNav_OnNavigateParentReadyForHome;
            this.AppNav.OnNavigateParentReadyForMotivation += AppNav_OnNavigateParentReadyForMotivation;
            this.AppNav.OnNavigateParentReadyForAddWorkout += AppNav_OnNavigateParentReadyForAddWorkout;
            this.AppNav.OnNavigateParentReadyForStatistics += AppNav_OnNavigateParentReadyForStatistics;
            this.AppNav.OnNavigateParentReadyForSettings += AppNav_OnNavigateParentReadyForSettings;

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
                //Frame.Navigate(typeof(StatisticsPage));
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
    }
}