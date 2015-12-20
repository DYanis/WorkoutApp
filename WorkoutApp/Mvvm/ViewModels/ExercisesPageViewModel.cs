namespace WorkoutApp.Mvvm.ViewModels
{
    public class ExercisesPageViewModel : ViewModelBase
    {
        public ExercisesPageViewModel()
        {
            this.VideoSrc = @"http://videocdn.bodybuilding.com/video/mp4/40000/40381m.mp4";
            this.VideoTitle = "Isometric neck exercise";
        }

        public string Title
        {
            get
            {
                return "Exercises";
            }
        }

        public string VideoSrc { get; set; }

        public string VideoTitle { get; set; }
    }
}
