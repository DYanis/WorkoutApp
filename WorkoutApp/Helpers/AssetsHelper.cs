namespace WorkoutApp.Helpers
{
    using System;
    using Windows.Storage;
    using Windows.Web.Http;

    public class AssetsHelper
    {
        string tipsUrl = @"http://filebin.ca/2QbUWUJVX97k/Tips.txt";
        HttpClient httpClient;

        public AssetsHelper()
        {
            this.httpClient = new HttpClient();
        }

        public async void GetTipsData()
        {
            var response = await this.httpClient.GetAsync(new Uri(tipsUrl));
            var result = await response.Content.ReadAsStringAsync();
            this.WriteTipsToStorage(result);
        }

        private async void WriteTipsToStorage(string tipsData)
        {
            try
            {
                var desiredFolder = ApplicationData.Current.LocalFolder;
                if (desiredFolder.TryGetItemAsync("Tips.txt") == null)
                {
                    await desiredFolder.CreateFileAsync("Tips.txt");
                    var file = await desiredFolder.GetFileAsync("Tips.txt");
                    await Windows.Storage.FileIO.WriteTextAsync(file, tipsData);
                    ToastHelper.PopToast("Tips", "Tips.txt was downloaded and updated.");
                }
                else
                {
                    ToastHelper.PopToast("Tips", "Tips.txt was downloaded but not updated, because it already exists.");
                }
            }
            catch (Exception)
            {
                ToastHelper.PopToast("Tips!", "Tips.txt download caused an error.");
            }
        }
    }
}