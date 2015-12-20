namespace WorkoutApp.Mvvm
{
    using SQLite.Net.Attributes;
    using System;

    public class DailyWorkout
    {

        [PrimaryKey]
        [AutoIncrement]
        public int ID { get; set; }

        public TimeSpan Start { get; set; }

        public WorkoutType Type { get; set; }

        public DayOfWeek Day { get; set; }

        public string Exercises { get; set; }
    }
}