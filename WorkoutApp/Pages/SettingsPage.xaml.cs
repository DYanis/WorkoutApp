namespace WorkoutApp.Pages
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using WorkoutApp.Mvvm.ViewModels;

    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
            this.DataContext = new SettingsPageViewModel();
        }

        private void OnGoToHomePageClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
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
