﻿namespace WorkoutApp.Mvvm.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    public class MainPageViewModel : IPageViewModel
    {
        private List<DailyWorkout> weekWorkouts;

        public string Title
        {
            get
            {
                return "Workout App";
            }
        }

        public List<DailyWorkout> WeekWorkouts
        {
            get
            {
                if (this.weekWorkouts == null)
                {
                    this.weekWorkouts = new List<DailyWorkout>();
                }

                return this.weekWorkouts;
            }
            set
            {
                if (this.weekWorkouts == null)
                {
                    this.weekWorkouts = new List<DailyWorkout>();
                }

                this.weekWorkouts.Clear();

                value.ToList().ForEach(this.weekWorkouts.Add);
            }
        }

        public string InspirationTipContent { get; set; }
    }
}