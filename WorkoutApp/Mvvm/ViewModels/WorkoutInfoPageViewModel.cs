namespace WorkoutApp.Mvvm.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class WorkoutInfoPageViewModel : ViewModelBase
    {
        private TimeSpan start;
        private WorkoutType type;
        private DayOfWeek day;

        private ObservableCollection<Exercise> exercises;

        public TimeSpan Start
        {
            get
            {
                return this.start;
            }
            set
            {
                this.start = value;
                this.RaisePropertyChanged("Start");
            }
        }

        public WorkoutType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
                this.RaisePropertyChanged("Type");
            }
        }

        public DayOfWeek Day
        {
            get
            {
                return this.day;
            }
            set
            {
                this.day = value;
                RaisePropertyChanged("Day");
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
