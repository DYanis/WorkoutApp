namespace WorkoutApp.Helpers
{
    using Windows.Networking.Connectivity;

    public static class GetInternetConnectionStatus
    {
        public static bool IsDeviceConnectedToTheInternet()
        {
            ConnectionProfile connections = NetworkInformation.GetInternetConnectionProfile();
            if (connections != null)
            {
                if (connections.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess)
                {
                    return true;
                }
                return false;
            }

            return false;
        }
    }
}