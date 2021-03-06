﻿namespace WorkoutApp.Pages
{
    using Helpers;
    using Mvvm;
    using SQLite.Net;
    using SQLite.Net.Async;
    using SQLite.Net.Platform.WinRT;
    using System;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.ApplicationModel;
    using Windows.Storage;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using WorkoutApp.Mvvm.ViewModels;

    public sealed partial class AddWorkoutPage : Page
    {
        private string curentView = "AddWorkout";

        public AddWorkoutPage()
        {
            this.InitializeComponent();
            this.DataContext = new AddWorkoutPageViewModel();
            this.weekDays.SelectedIndex = 0;
            this.workoutTypes.SelectedIndex = 0;
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

        private void OnAddNewExerciseClick(object sender, RoutedEventArgs e)
        {
            var newExercise = new Exercise()
            {
                Name = this.exerciseName.Text,
                Repetitions = (int)this.repetitions.SelectedValue,
                BreakTimes = (int)this.breakTimes.SelectedValue
            };

            this.exerciseName.Text = string.Empty;
            this.repetitions.SelectedValue = string.Empty;
            this.breakTimes.SelectedValue = string.Empty;

            (this.DataContext as AddWorkoutPageViewModel).Exercises.Add(newExercise);

            ToastHelper.PopToast("Workout template", string.Format("{0} was added to the workout.", this.exerciseName.Text));
        }

        private async void OnAddNewWorkoutClick(object sender, RoutedEventArgs e)
        {//TODO: can throw notification when user add without added exercises
            var exercises = new StringBuilder();

            foreach (var exercise in (this.DataContext as AddWorkoutPageViewModel).Exercises)
            {
                exercises.Append(exercise.Name + "/");
                exercises.Append(exercise.Repetitions + "/");
                exercises.Append(exercise.BreakTimes + "/");
                exercises.Append("$");
            }

            var newDailyWorkout = new DailyWorkout()
            {
                Day = (DayOfWeek)this.weekDays.SelectedValue,
                Exercises = exercises.ToString(),
                Start = this.workoutTime.Time,
                Type = (WorkoutType)this.workoutTypes.SelectedValue
            };

            ToastHelper.PopToast("Workout", "Added to reminders.");

            await InserWorkoutAsync(newDailyWorkout);
            this.Frame.Navigate(typeof(MainPage));
        }

        private SQLiteAsyncConnection GetDbConnectionAsync()
        {
            var dbFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "db.sqlite");

            var connectionFactory =
                new Func<SQLiteConnectionWithLock>(
                    () =>
                    new SQLiteConnectionWithLock(
                        new SQLitePlatformWinRT(),
                        new SQLiteConnectionString(dbFilePath, storeDateTimeAsTicks: false)));

            var asyncConnection = new SQLiteAsyncConnection(connectionFactory);

            return asyncConnection;
        }

        private async Task<int> InserWorkoutAsync(DailyWorkout newWourkout)
        {
            var connection = this.GetDbConnectionAsync();
            var result = await connection.InsertAsync(newWourkout);
            return result;
        }

        private void OnRemoveExerciseClick(object sender, RoutedEventArgs e)
        {
            var data = (sender as AppBarButton).DataContext;
            var exerciseInfo = (data as Exercise);
            var exercise = new Exercise()
            {
                Name = exerciseInfo.Name,
                BreakTimes = exerciseInfo.BreakTimes,
                Repetitions = exerciseInfo.Repetitions

            };

            (this.DataContext as AddWorkoutPageViewModel).Exercises.Remove(exercise);
        }
    }
}