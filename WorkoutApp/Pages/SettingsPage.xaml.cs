namespace WorkoutApp.Pages
{
    using Helpers;
    using System;
    using Windows.ApplicationModel;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using WorkoutApp.Mvvm.ViewModels;

    public sealed partial class SettingsPage : Page
    {
        private string curentView = "Settings";

        public SettingsPage()
        {
            this.InitializeComponent();
            this.DataContext = new SettingsPageViewModel();

            this.AppNav.OnNavigateParentReadyForHome += AppNav_OnNavigateParentReadyForHome;
            this.AppNav.OnNavigateParentReadyForMotivation += AppNav_OnNavigateParentReadyForMotivation;
            this.AppNav.OnNavigateParentReadyForAddWorkout += AppNav_OnNavigateParentReadyForAddWorkout;
            this.AppNav.OnNavigateParentReadyForStatistics += AppNav_OnNavigateParentReadyForStatistics;
            this.AppNav.OnNavigateParentReadyForSettings += AppNav_OnNavigateParentReadyForSettings;

            Application.Current.Resuming += new EventHandler<Object>(App_Resuming);
            Application.Current.Suspending += new SuspendingEventHandler(App_Suspending);
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

        private void SaveSettingsAsync(object sender, RoutedEventArgs e)
        {
            if (this.SCOn.IsChecked != null)
            {
                if (this.SCOn.IsChecked == true)
                {
                    SettingsHelper.IsCapturable = true;
                }
                else
                {
                    SettingsHelper.IsCapturable = false;
                }
            }

            if (this.APVOn.IsChecked != null)
            {
                if (this.SCOn.IsChecked == true)
                {
                    SettingsHelper.IsAutoPlayable = true;
                }
                else
                {
                    SettingsHelper.IsAutoPlayable = false;
                }
            }

            ToastHelper.PopToast("Settings", "Updated");
        }
    }
}