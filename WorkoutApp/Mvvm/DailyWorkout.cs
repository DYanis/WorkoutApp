namespace WorkoutApp.Mvvm
{
    using System;

    public class DailyWorkout
    {
        public TimeSpan Start { get; set; }

        public WorkoutType Type { get; set; }

        public DayOfWeek Day { get; set; }
    }
}
