namespace WorkoutApp.Mvvm
{
    using SQLite.Net.Attributes;

    public class Exercise
    {
        [PrimaryKey]
        [AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public int Repetitions { get; set; }

        public int BreakTimes { get; set; }

        public int DailyWorkoutID { get; set; }

        public virtual DailyWorkout DailyWorkout { get; set; }
    }
}