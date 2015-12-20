namespace WorkoutApp.Mvvm.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class AddWorkoutPageViewModel : ViewModelBase
    {
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
    }
}
