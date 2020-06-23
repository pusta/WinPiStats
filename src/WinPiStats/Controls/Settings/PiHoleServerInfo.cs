using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinPiStats.Controls.Settings
{
    public class PiHoleServerInfo
    {

        public string PiHoleServerName { get; set; }
        public string PiHoleServerAddress { get; set; }
        public string PiHoleServerAuthKey { get; set; }


        public string HostNameSummary
        {
            get
            {
                return this.PiHoleServerName;
            }
        }
    }
}

    
