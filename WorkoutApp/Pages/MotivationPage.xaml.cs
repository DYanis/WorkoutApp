namespace WorkoutApp.Pages
{
    using Helpers;
    using Mvvm.ViewModels;
    using System;
    using Windows.ApplicationModel;
    using Windows.Networking.Connectivity;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class MotivationPage : Page
    {
        private string curentView = "Motivation";
        private bool isPlaying = true;
        private bool connectionAvailable = true;

        public MotivationPage()
        {
            this.InitializeComponent();
            this.DataContext = new ExercisesPageViewModel();

            this.AppNav.OnNavigateParentReadyForHome += AppNav_OnNavigateParentReadyForHome;
            this.AppNav.OnNavigateParentReadyForMotivation += AppNav_OnNavigateParentReadyForMotivation;
            this.AppNav.OnNavigateParentReadyForAddWorkout += AppNav_OnNavigateParentReadyForAddWorkout;
            this.AppNav.OnNavigateParentReadyForStatistics += AppNav_OnNavigateParentReadyForStatistics;
            this.AppNav.OnNavigateParentReadyForSettings += AppNav_OnNavigateParentReadyForSettings;

            Application.Current.Resuming += new EventHandler<Object>(App_Resuming);
            Application.Current.Suspending += new SuspendingEventHandler(App_Suspending);

            this.IsConnected();
            if (!this.connectionAvailable)
            {
                this.playPauseBtn.IsEnabled = false;
                this.rewindBtn.IsEnabled = false;
                this.forwardBtn.IsEnabled = false;
                this.newExerciseBtn.IsEnabled = false;
                ToastHelper.PopToast("Alert", "Videos disabled. No internet connection available.");
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

        private void OnGoToHomePageClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void OnGoToSettingsPageClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SettingsPage));
        }

        private void OnAddWorkoutClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddWorkoutPage));
        }

        private void IsConnected()
        {
            ConnectionProfile connectionProfile = NetworkInformation.GetInternetConnectionProfile();
            bool internetConnectivity = ((connectionProfile != null) && (connectionProfile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess));
            this.connectionAvailable = internetConnectivity;
        }

        public void MediaRewind(object sender, RoutedEventArgs e)
        {
            if (connectionAvailable)
            {
                if ((this.MediaElement.Position - TimeSpan.FromSeconds(5)) > TimeSpan.FromSeconds(0))
                {
                    this.MediaElement.Position = this.MediaElement.Position - TimeSpan.FromSeconds(5);
                }
            }
            else
            {
            }
        }

        public void MediaForward(object sender, RoutedEventArgs e)
        {
            if (connectionAvailable)
            {
                if ((this.MediaElement.Position + TimeSpan.FromSeconds(5)) < MediaElement.NaturalDuration.TimeSpan)
                {
                    this.MediaElement.Position = this.MediaElement.Position + TimeSpan.FromSeconds(5);
                }
            }
            else
            {
            }
        }

        public void MediaPlayPause(object sender, RoutedEventArgs e)
        {
            if (connectionAvailable)
            {
                if (this.isPlaying == true)
                {
                    this.MediaElement.Pause();
                    this.isPlaying = false;
                }
                else
                {
                    this.MediaElement.Play();
                    this.isPlaying = true;
                }
            }
            else
            {
            }
        }

        public async void GetMeANewExerciseAsync(object sender, RoutedEventArgs e)
        {
            if (connectionAvailable)
            {
                var exerciseManager = new GetRandomExercise();
                Tuple<string, string> exercise = await exerciseManager.GetRandomExerciseAsync();
                this.MediaElement.Source = new Uri(exercise.Item2);
                this.ExerciseTitle.Text = exercise.Item1;
                ToastHelper.PopToast("Now watching", exercise.Item1);
            }
            else
            {
            }
        }

        public bool GetPlaySetting
        {
            get
            {
                return this.isPlaying;
            }
        }
    }
}