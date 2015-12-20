namespace WorkoutApp.Pages
{
    using CustomControls;
    using Helpers;
    using System;
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

            //TODO: Navigation events
            //this.AppNav.OnNavigateParentReadyForHome += AppNav_OnNavigateParentReadyForHome;
            //this.AppNav.OnNavigateParentReadyForMotivation += AppNav_OnNavigateParentReadyForMotivation;
            //this.AppNav.OnNavigateParentReadyForAddWorkout += AppNav_OnNavigateParentReadyForAddWorkout;
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

        }
    }
}