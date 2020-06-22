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
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        public string piHoleName { get; }
        public string piHoleAddress { get; }
        public string piHoleAuthKey { get; }

       


        public PiHoleSettings(string piholeServerNumber)
        {

            piHoleName = localSettings.Values["PiHoleServerName" + '-' + piholeServerNumber].ToString();
            piHoleAddress = localSettings.Values["PiHoleAddress" + '-' + piholeServerNumber].ToString();
            piHoleAuthKey = localSettings.Values["PiHoleAuthKey" + '-' + piholeServerNumber].ToString();


        }



    }
}
