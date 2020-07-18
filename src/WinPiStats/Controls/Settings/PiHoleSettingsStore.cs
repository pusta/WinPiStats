using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WinPiStats.Controls.Settings
{
    public class PiHoleSettingsStore : INotifyPropertyChanged
    {

        LocalObjectStorageHelper helper = new LocalObjectStorageHelper();
        private ObservableCollection<PiHoleServerInfo> serverlist = new ObservableCollection<PiHoleServerInfo>();
        public ObservableCollection<PiHoleServerInfo> ServerList { get { return this.serverlist; } }
        private string serverNumber;

        public event PropertyChangedEventHandler PropertyChanged;

        public PiHoleSettingsStore(string serverNum)
        {
            serverNumber = serverNum;

        }

        public PiHoleSettingsStore()
        {
            ListViewModel();

        }

        public void Save_Settings(PiHoleServerInfo serverInfo)
        {

            helper.Save(serverNumber, serverInfo);
            //var index = serverlist.IndexOf(serverInfo);
            this.serverlist.Add(new PiHoleServerInfo() { PiHoleServerName = serverInfo.PiHoleServerName, PiHoleServerAddress = serverInfo.PiHoleServerAddress, PiHoleServerAuthKey = serverInfo.PiHoleServerAuthKey });




        }

        public PiHoleServerInfo Retrive_Settings()
        {
            var result = helper.Read<PiHoleServerInfo>(serverNumber);

            return result;


        }



        public void ListViewModel()
        {

            for (var i = 1; i <= Convert.ToInt32(new ServerCount().NumberOfServers); i++)
            {
                var piholesettingsstore = new PiHoleSettingsStore(i.ToString());
                var piholeserverinfo = new PiHoleServerInfo();
                piholeserverinfo = piholesettingsstore.Retrive_Settings();
                this.serverlist.Add(new PiHoleServerInfo() { PiHoleServerName = piholeserverinfo.PiHoleServerName, PiHoleServerAddress = piholeserverinfo.PiHoleServerAddress, PiHoleServerAuthKey = piholeserverinfo.PiHoleServerAuthKey });

            }



        }

        protected void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));

        }
        
            

    

    
        


    }
}
