using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WinPiStats.Controls.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WinPiStats.Views.Content
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ContentPage : Page
    {
        public ContentPage()
        {
            this.InitializeComponent();
            PiHoleAPI piholeapi = new PiHoleAPI("192.168.113.10", "8b110955b9df47b0b7c3a623e600f030394e203a0abdde4f0e5a498af953a6f8");
            blockedTextBlock.Text = piholeapi.Query_Pihole_Domains();
            queriesTodayTextBlock.Text = piholeapi.Total_Queries_Today();
            //blockedTextbox.Text = piholeapi
            PiholeStateCheck();
        }


        private void PiholeStateCheck()
        {
            var piholeapi = new PiHoleAPI("192.168.113.10", "8b110955b9df47b0b7c3a623e600f030394e203a0abdde4f0e5a498af953a6f8");

            if (piholeapi.Is_Pihole_Enabled())
            {
                isEnabledTextBlock.Text = "Enabled";
                toggleStateButton.Content = "Disable";
            }
            else
            {
                isEnabledTextBlock.Text = "Disabled";
                toggleStateButton.Content = "Enable";
            }


        }

        private void toggleStateButton_Click(object sender, RoutedEventArgs e)
        {
            var piholeapi = new PiHoleAPI("192.168.113.10", "8b110955b9df47b0b7c3a623e600f030394e203a0abdde4f0e5a498af953a6f8");

            if (piholeapi.Is_Pihole_Enabled())
                piholeapi.Pihole_Change_State("disable");
            else
                piholeapi.Pihole_Change_State("enable");

            PiholeStateCheck();
        }
    }
}
