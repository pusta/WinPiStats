using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinPiStats.Base;

namespace WinPiStats.Controls.Settings
{
    public class PiHoleServerInfo : Observable
    {

        private string _piholeservername;
        private string _piholeserveraddress;
        private string _piholeauthkey;
        
        LocalObjectStorageHelper helper = new LocalObjectStorageHelper();

        public string PiHoleServerName
        {
            get
            { return _piholeservername; }
            set
            { _piholeservername = value; 
                OnPropertyChanged(); }
        }


        public string PiHoleServerAddress { 
            get
            {
                return _piholeserveraddress;
            }
                set
            {
                _piholeserveraddress = value;
                OnPropertyChanged();
            }
        
        }
        public string PiHoleServerAuthKey {

            get
            {
                return _piholeauthkey;
            }
            set
            {
                _piholeauthkey = value;
                OnPropertyChanged();
            }





        }
        

        /*public string HostNameSummary
        {
            get
            {
                return this.PiHoleServerName;
            }
        }*/


        public void Save_Settings(PiHoleServerInfo serverInfo, string serverNumber)
        {

            helper.Save(serverNumber, serverInfo);
            
            



        }

        public PiHoleServerInfo Retrive_Settings(string serverNumber)
        {
            var result = helper.Read<PiHoleServerInfo>(serverNumber);

            return result;


        }


        
    }
}

    
