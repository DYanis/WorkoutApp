namespace WorkoutApp.Helpers
{
    using Windows.Networking.Connectivity;

    public static class ConnectionHelper
    {
        public static bool IsDeviceConnectedToTheInternet()
        {
            ConnectionProfile connectionProfile = NetworkInformation.GetInternetConnectionProfile();

            bool internetConnectivity = ((connectionProfile != null) && (connectionProfile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess));

            return internetConnectivity;
        }
    }
}