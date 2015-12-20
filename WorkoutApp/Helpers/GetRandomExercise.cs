namespace WorkoutApp.Helpers
{
    using System;
    using System.Threading.Tasks;
    using Windows.Storage;

    public class GetRandomExercise
    {
        Random random = new Random();

        public async Task<Tuple<string, string>> GetRandomExerciseAsync()
        {
            var desiredFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            desiredFolder = await desiredFolder.GetFolderAsync("Assets");

            var file = await desiredFolder.GetFileAsync("Exercises.txt");

            var fileContent = await FileIO.ReadTextAsync(file);
            var splittedFileContent = fileContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            int id = random.Next(0, splittedFileContent.Length);

            var output = splittedFileContent[id].Split(',');
            return new Tuple<string, string>(output[0], output[1]);
        }
    }
}