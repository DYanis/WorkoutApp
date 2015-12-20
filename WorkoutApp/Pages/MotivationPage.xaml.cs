namespace WorkoutApp.Pages
{
    using Helpers;
    using Mvvm.ViewModels;
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class MotivationPage : Page
    {
        private bool isPlaying = true;

        public MotivationPage()
        {
            this.InitializeComponent();
            this.DataContext = new ExercisesPageViewModel();
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

        public void MediaRewind(object sender, RoutedEventArgs e)
        {
            if ((this.MediaElement.Position - TimeSpan.FromSeconds(5)) > TimeSpan.FromSeconds(0))
            {
                this.MediaElement.Position = this.MediaElement.Position - TimeSpan.FromSeconds(5);
            }
        }

        public void MediaForward(object sender, RoutedEventArgs e)
        {
            if ((this.MediaElement.Position + TimeSpan.FromSeconds(5)) < MediaElement.NaturalDuration.TimeSpan)
            {
                this.MediaElement.Position = this.MediaElement.Position + TimeSpan.FromSeconds(5);
            }
        }

        public void MediaPlayPause(object sender, RoutedEventArgs e)
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

        public async void GetMeANewExerciseAsync(object sender, RoutedEventArgs e)
        {
            bool isConnected = GetInternetConnectionStatus.IsDeviceConnectedToTheInternet();
            if (isConnected)
            {
                var exerciseManager = new GetRandomExercise();
                Tuple<string, string> exercise = await exerciseManager.GetRandomExerciseAsync();
                this.MediaElement.Source = new Uri(exercise.Item2);
                this.ExerciseTitle.Text = exercise.Item1;
            }
        }
    }
}
