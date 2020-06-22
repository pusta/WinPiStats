using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace WinPiStats.Controls.Settings
{
    class PiHoleSettings
    {
        public string piHoleName { get; set; }
        public string piHoleAddress { get; set; }
        public string piHoleAuthKey { get; set; }

        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;


        public PiHoleSettings(string piholeServerNumber)
        {

            piHoleName = localSettings.Values["PiHoleServerName" + '-' + piholeServerNumber].ToString();
            piHoleAddress = localSettings.Values["PiHoleAddress" + '-' + piholeServerNumber].ToString();
            piHoleAuthKey = localSettings.Values["PiHoleAuthKey" + '-' + piholeServerNumber].ToString();


        }



    }
}
