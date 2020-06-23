using System;
using System.Collections.ObjectModel;
using WinPiStats.Controls.Settings;

namespace WinPiStats.Models
{
    public class ListViewModel
    {

        private ObservableCollection<PiHoleServerInfo> serverlist = new ObservableCollection<PiHoleServerInfo>();
        public ObservableCollection<PiHoleServerInfo> ServerList { get { return this.serverlist; } }

        public ListViewModel()
        {

            for (var i = 1; i <= Convert.ToInt32(new ServerCount().NumberOfServers); i++)
            {
                var piholesettingsstore = new PiHoleSettingsStore(i.ToString());
                var piholeserverinfo = new PiHoleServerInfo();
                piholeserverinfo = piholesettingsstore.Retrive_Settings();
                this.serverlist.Add(new PiHoleServerInfo() { PiHoleServerName = piholeserverinfo.PiHoleServerName, PiHoleServerAddress = piholeserverinfo.PiHoleServerAddress, PiHoleServerAuthKey = piholeserverinfo.PiHoleServerAuthKey });

            }


            
        }


    }
}
