using System;
using Windows.Storage;


namespace WinPiStats.Controls.Settings
{
    class ServerCount
    {

        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public int NumberOfServers { 
            
            get
            {

                return Convert.ToInt32(localSettings.Values["NumberofServers"]);
                

            }
            
            set
            {

                localSettings.Values["NumberofServers"] = value;



            }
                
        }












    }
}
