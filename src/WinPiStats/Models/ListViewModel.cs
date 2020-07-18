using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WinPiStats.Controls.Settings;
using WinPiStats.Base;
using WinPiStats.Views.Settings;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace WinPiStats.Models
{
    public class ListViewModel : Observable
    {

        private ObservableCollection<PiHoleServerInfo> serverlist = new ObservableCollection<PiHoleServerInfo>();
        public ObservableCollection<PiHoleServerInfo> ServerList { get { return this.serverlist; } }
        private PiHoleServerInfo _selectedserver;

        

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

        public PiHoleServerInfo SelectedServer
        {
            get { return _selectedserver; }

            set
            {
                if (_selectedserver != value)
                { 
                _selectedserver = value;
                    
                OnPropertyChanged();
                }
            }
        }


    }
}
