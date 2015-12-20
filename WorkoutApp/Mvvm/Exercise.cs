namespace WorkoutApp.Mvvm
{
    public class Exercise
    {
        public string Name { get; set; }

        public int Repetitions { get; set; }

        public int BreakTimes { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Exercise;

            if (other.Name != this.Name)
            {
                return false;
            }

            if (other.Repetitions != this.Repetitions)
            {
                return false;
            }

            if (other.BreakTimes != this.BreakTimes)
            {
                return false;
            }

            return true;
        }
    }
}