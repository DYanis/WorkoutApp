namespace WorkoutApp.Pages
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using WorkoutApp.Mvvm.ViewModels;

    public sealed partial class AddWorkoutPage : Page
    {
        public AddWorkoutPage()
        {
            this.InitializeComponent();
            this.DataContext = new AddWorkoutPageViewModel();
            this.weekDays.SelectedIndex = 0;
        }

        private void OnGoToHomePageClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void OnGoToMotivationPageClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MotivationPage));
        }

        private void OnGoToSettingsPageClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SettingsPage));
        }
    }
}
