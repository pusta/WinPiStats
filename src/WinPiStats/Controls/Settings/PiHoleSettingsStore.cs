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
        private string serverNumber;

        public PiHoleSettingsStore(string serverNum)
        {
            serverNumber = serverNum;

        }

        public void Save_Settings(PiHoleServerInfo serverInfo)
        {

            helper.Save(serverNumber, serverInfo);

           

        }

        public PiHoleServerInfo Retrive_Settings()
        {
            var result = helper.Read<PiHoleServerInfo>(serverNumber);

            return result;


        }


    }
}
