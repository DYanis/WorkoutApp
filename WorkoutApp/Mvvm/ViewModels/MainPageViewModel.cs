namespace WorkoutApp.Mvvm.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Linq;

    public class MainPageViewModel : IPageViewModel
    {
        private ObservableCollection<DailyWorkout> weekWorkouts;

        public string Title
        {
            get
            {
                return "Workout App";
            }
        }

        public ObservableCollection<DailyWorkout> WeekWorkouts
        {
            get
            {
                if (this.weekWorkouts == null)
                {
                    this.weekWorkouts = new ObservableCollection<DailyWorkout>();
                }

                return this.weekWorkouts;
            }
            set
            {
                if (this.weekWorkouts == null)
                {
                    this.weekWorkouts = new ObservableCollection<DailyWorkout>();
                }

                this.weekWorkouts.Clear();

                value.ToList().ForEach(this.weekWorkouts.Add);
            }
        }


        public string InspirationTipContent { get; set; }
    }
}