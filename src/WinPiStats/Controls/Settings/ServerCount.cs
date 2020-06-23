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

        public void Increase_Servers()
        {

            if (this.NumberOfServers == 0)
            {
               this.NumberOfServers = 1;

            }
            else
            {
                var numServers = this.NumberOfServers;
                numServers += numServers;
                this.NumberOfServers = numServers;




            }







        }










    }
}
