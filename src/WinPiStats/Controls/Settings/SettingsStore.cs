using System;
using Windows.Storage;

namespace WinPiStats.Controls.Settings
{
    class SettingsStore
    {

        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        private string serverNumber;



        public SettingsStore()
        {



        }

        public SettingsStore(string serverNum)
        {

            serverNumber = serverNum;

        }
        
        public void Store_Settings(string serverName, string AuthKey, string serverAddress)
        {
            localSettings.Values["PiHoleServerName" + '-' + serverNumber] = serverName;
            localSettings.Values["PiHoleAuthKey" + '-' + serverNumber] = AuthKey;
            localSettings.Values["PiHoleAddress" + '-' + serverNumber] = serverAddress;

            if (localSettings.Values["NumberofServers"] == null)
            {
                localSettings.Values["NumberofServers"] = 1;

            }
            else
            {
                var numServers = Convert.ToInt32(localSettings.Values["NumberofServers"]);
                numServers += numServers;
                localSettings.Values["NumberofServers"] = numServers;




            }

        }

        public void First_Run(bool firstRun)
        {

            localSettings.Values["First_Run"] = firstRun;




        }

        public string Number_of_Servers()
        {


            var numServers = localSettings.Values["NumberofServers"].ToString();
            return numServers;



        }
        



    }
}
