namespace WorkoutApp.Pages
{
    using Helpers;
    using Mvvm.ViewModels;
    using System;
    using Windows.ApplicationModel;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;

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

            //TODO: Input and gesture processing and showcase
            inputTarget.PointerPressed += new PointerEventHandler(target_PointerPressed);
            inputTarget.PointerReleased += new PointerEventHandler(target_PointerReleased);

            inputTarget.PointerEntered += new PointerEventHandler(target_PointerEntered);
            inputTarget.PointerExited += new PointerEventHandler(target_PointerExited);

            inputTarget.Tapped += new TappedEventHandler(target_Tapped);
            inputTarget.DoubleTapped += new DoubleTappedEventHandler(target_DoubleTapped);

            inputTarget.Holding += new HoldingEventHandler(target_Holding);
            inputTarget.RightTapped += new RightTappedEventHandler(target_RightTapped);
        }

        void target_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ToastHelper.PopToast("Gesture", "Press/Touch");
        }

        void target_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            ToastHelper.PopToast("Gesture", "Press/Touch release");
        }

        void target_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            ToastHelper.PopToast("Gesture", "Entered screen area");
        }

        void target_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            ToastHelper.PopToast("Gesture", "Exited screen area");
        }

        void target_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ToastHelper.PopToast("Gesture", "Click/Tap");
        }

        void target_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            ToastHelper.PopToast("Gesture", "Double click/tap");
        }

        void target_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            ToastHelper.PopToast("Gesture", "Right click/tap");
        }

        void target_Holding(object sender, HoldingRoutedEventArgs e)
        {
            if (e.HoldingState == Windows.UI.Input.HoldingState.Started)
            {
                ToastHelper.PopToast("Gesture", "Holding");
            }
            else if (e.HoldingState == Windows.UI.Input.HoldingState.Completed)
            {
                ToastHelper.PopToast("Gesture", "Held");
            }
            else
            {
                ToastHelper.PopToast("Gesture", "Hold canceled");
            }
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