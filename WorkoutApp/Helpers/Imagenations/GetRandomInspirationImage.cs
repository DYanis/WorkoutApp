using Windows.ApplicationModel.Background;

namespace WorkoutApp.Helpers.Imagenations
{
    public class GetRandomInspirationImage
    {
        TimeTrigger hourlyTrigger;

        public GetRandomInspirationImage()
        {
            //TODO: Create repeating task, 60 min interval
            hourlyTrigger = new TimeTrigger(60, false);
        }

        public async void GetInspirationImageAsync()
        {

        }
    }
}