using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPiStats.Controls.Settings
{
    class PiHoleSettingsStore
    {

        LocalObjectStorageHelper helper = new LocalObjectStorageHelper();
        ServerCount servercount;
        private string serverNumber;

        public PiHoleSettingsStore(string serverNum)
        {
            serverNumber = serverNum;

        }

        public void Save_Settings(PiHoleServerInfo serverInfo)
        {

            helper.Save(serverNumber, serverInfo);

            servercount = new ServerCount();

            if (servercount.NumberOfServers == 0)
            {
                servercount.NumberOfServers = 1;

            }
            else
            {
                var numServers = servercount.NumberOfServers;
                numServers += numServers;
                servercount.NumberOfServers = numServers;




            }

        }

        public PiHoleServerInfo Retrive_Settings()
        {
            var result = helper.Read<PiHoleServerInfo>(serverNumber);

            return result;


        }


    }
}
