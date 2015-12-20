namespace WorkoutApp.Helpers.Inspirations
{
    using System;
    using System.Threading.Tasks;
    using Windows.Storage;

    public class GetRandomInspirationTip
    {
        Random random = new Random();

        public async Task<string> GetInspirationTipAsync()
        {
            var desiredFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            desiredFolder = await desiredFolder.GetFolderAsync("Assets");

            var file = await desiredFolder.GetFileAsync("Tips.txt");

            //// tips for how to write content
            //var test = "Hello World";
            //await Windows.Storage.FileIO.WriteTextAsync(file, test);

            var fileContent = await FileIO.ReadTextAsync(file);
            var splittedFileContent = fileContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            
            int id = random.Next(0, splittedFileContent.Length);

            string output = splittedFileContent[id];
            return output;
        }
    }
}