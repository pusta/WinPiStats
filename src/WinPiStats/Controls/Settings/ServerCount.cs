using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;


namespace WinPiStats.Controls.Settings
{
    class ServerCount
    {

        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public string NumberOfServers { 
            
            get
            {

                return localSettings.Values["NumberofServers"].ToString();
                

            }
            
            set
            {

                localSettings.Values["NumberofServers"] = value;



            }
                
        }












    }
}
