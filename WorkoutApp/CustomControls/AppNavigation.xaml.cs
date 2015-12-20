﻿namespace WorkoutApp.CustomControls
{
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class AppNavigation : UserControl
    {
        public delegate void MyEventHandler(object source, EventArgs e);

        public event MyEventHandler OnNavigateParentReadyForHome;

        public event MyEventHandler OnNavigateParentReadyForMotivation;

        public event MyEventHandler OnNavigateParentReadyForAddWorkout;

        public AppNavigation()
        {
            this.InitializeComponent();
        }

        private void OnGoToHomePageClick(object sender, RoutedEventArgs e)
        {
            this.OnNavigateParentReadyForHome(this, null);
        }

        private void OnGoToMotivationPageClick(object sender, RoutedEventArgs e)
        {
            this.OnNavigateParentReadyForMotivation(this, null);
        }

        private void OnGoToAddWorkoutPageClick(object sender, RoutedEventArgs e)
        {
            this.OnNavigateParentReadyForAddWorkout(this, null);
        }
    }
}
