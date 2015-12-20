namespace WorkoutApp.Mvvm.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class AddWorkoutPageViewModel : ViewModelBase
    {
        private ObservableCollection<Exercise> exercises;

        public string Title
        {
            get
            {
                return "Add Workout";
            }
        }

        public List<DayOfWeek> WeekDays
        {
            get
            {
                return new List<DayOfWeek>()
                {
                    DayOfWeek.Monday,
                    DayOfWeek.Tuesday,
                    DayOfWeek.Wednesday,
                    DayOfWeek.Thursday,
                    DayOfWeek.Friday,
                    DayOfWeek.Saturday,
                    DayOfWeek.Sunday,
                };
            }
        }

        public List<WorkoutType> WorkoutTypes
        {
            get
            {
                return new List<WorkoutType>()
                {
                    WorkoutType.StreetWourkout,
                    WorkoutType.Fitness,
                    WorkoutType.Cardio,
                    WorkoutType.CrossFit
                };
            }
        }

        public List<int> Repetitions
        {
            get
            {
                return new List<int>()
                {
                    1, 2, 3, 4, 5, 6, 7, 8, 9
                };
            }
        }

        public List<int> BreakTimes
        {
            get
            {
                return new List<int>()
                {
                    10, 20, 30, 40, 50, 60, 70, 80, 90, 100,
                    110, 120, 130, 140, 150, 160, 170, 180, 190, 200,
                    210, 220, 230, 240, 250, 260, 270, 280, 290, 300
                };
            }
        }

        public ObservableCollection<Exercise> Exercises
        {
            get
            {
                if (this.exercises == null)
                {
                    this.exercises = new ObservableCollection<Exercise>();
                }

                return this.exercises;
            }
            set
            {
                if (this.exercises == null)
                {
                    this.exercises = new ObservableCollection<Exercise>();
                }

                this.exercises.Clear();

                value.ToList().ForEach(this.exercises.Add);
            }
        }
    }
}