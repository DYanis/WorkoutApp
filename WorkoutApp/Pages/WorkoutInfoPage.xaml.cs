namespace WorkoutApp.Pages
{
    using Mvvm;
    using Mvvm.ViewModels;
    using SQLite.Net;
    using SQLite.Net.Async;
    using SQLite.Net.Platform.WinRT;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Windows.Storage;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class WorkoutInfoPage : Page
    {
        public WorkoutInfoPage()
        {
            this.InitializeComponent();
            this.DataContext = new WorkoutInfoPageViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var grid = e.Parameter as Grid;
            var workout = grid.DataContext as DailyWorkout;
            var exercises = ParseExercise(workout);
            //this.DataContext = grid.DataContext;
            var page = (this.DataContext as WorkoutInfoPageViewModel);
            page.Exercises = exercises;
            page.Day = workout.Day;
            page.Start = workout.Start;
            page.Type = workout.Type;
        }

        private ObservableCollection<Exercise> ParseExercise(DailyWorkout workout)
        {
            var exercisesObjects = new ObservableCollection<Exercise>();
            var exercises = workout.Exercises.Trim().Split('$');

            foreach (var item in exercises)
            {
                if (item != string.Empty)
                {
                    var exInfo = item.Split('/');

                    var newExercises = new Exercise()
                    {
                        Name = exInfo[0],
                        Repetitions = int.Parse(exInfo[1]),
                        BreakTimes = int.Parse(exInfo[2])
                    };

                    exercisesObjects.Add(newExercises);
                }
            }

            return exercisesObjects;
        }
    }
}
