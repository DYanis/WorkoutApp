namespace WorkoutApp.Pages
{
    using Helpers;
    using Mvvm.ViewModels;
    using System;
    using Windows.ApplicationModel;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class StatisticsPage : Page
    {
        Library animationLibrary;
        private string curentView = "Statistics";

        public StatisticsPage()
        {
            this.InitializeComponent();
            this.DataContext = new StatisticsPageViewModel();

            this.AppNav.OnNavigateParentReadyForHome += AppNav_OnNavigateParentReadyForHome;
            this.AppNav.OnNavigateParentReadyForMotivation += AppNav_OnNavigateParentReadyForMotivation;
            this.AppNav.OnNavigateParentReadyForAddWorkout += AppNav_OnNavigateParentReadyForAddWorkout;
            this.AppNav.OnNavigateParentReadyForStatistics += AppNav_OnNavigateParentReadyForStatistics;
            this.AppNav.OnNavigateParentReadyForSettings += AppNav_OnNavigateParentReadyForSettings;

            Application.Current.Resuming += new EventHandler<Object>(App_Resuming);
            Application.Current.Suspending += new SuspendingEventHandler(App_Suspending);

            animationLibrary = new Library();

            this.StartRandomEffect();
        }

        private void StartRandomEffect()
        {
            Random random = new Random();
            int selector = random.Next(0, 3);
            switch (selector)
            {
                case 0:
                    animationLibrary.Rotate("X", ref Display);
                    break;
                case 1:
                    animationLibrary.Rotate("Z", ref Display);
                    break;
                default:
                    animationLibrary.Rotate("Y", ref Display);
                    break;
            }
        }

        private void App_Suspending(object sender, SuspendingEventArgs e)
        {
            ToastHelper.PopToast("Workout", "Suspend");
        }

        private void App_Resuming(object sender, object e)
        {
            ToastHelper.PopToast("Workout", "Resume/Start");
        }

        private void AppNav_OnNavigateParentReadyForHome(object source, EventArgs e)
        {
            if (curentView != "Home")
            {
                Frame.Navigate(typeof(MainPage));
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
    }
}