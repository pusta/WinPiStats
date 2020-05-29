using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using System.Xml;
using Windows.Storage;
using System.Net.Http;
using Windows.Data.Json;
using Windows.UI.Core;
using WinPiStats.Views.Settings;



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WinPiStats.Views.MainPage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            PiHoleAPI piholeapi = new PiHoleAPI("192.168.113.10", "8b110955b9df47b0b7c3a623e600f030394e203a0abdde4f0e5a498af953a6f8");
            blockedTextBlock.Text = piholeapi.Query_Pihole_Domains();
            queriesTodayTextBlock.Text = piholeapi.Total_Queries_Today();
            //blockedTextbox.Text = piholeapi
            PiholeStateCheck();
            
            
           
            

              



            
        }

        public async void Launch_Win32()
        {
            if (ApiInformation.IsApiContractPresent("Windows.ApplicationModel.FullTrustAppContract", 1, 0))
            {
                await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync();
            }


        }

        private void Page_Loading(FrameworkElement sender, object args)
        {
            //read settings
           ReadSettings();
            
        }

        private void ReadSettings()
        {

            ApplicationDataContainer settings = ApplicationData.Current.LocalSettings;


        }

        /*public async  void PullPiHoleJson()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://192.168.113.10/admin/api.php?summary");

            var stringData = response.Content.ReadAsStringAsync().Result;

            var rootObject = JsonObject.Parse(stringData);

            blockedTextbox.Text = rootObject["domains_being_blocked"].ToString().Trim('"');



        }*/

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

        private void mainNav_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {

            if (args.IsSettingsSelected)
            {
                settingsFrame.Navigate(typeof(Testpage));
                //mainNav.IsBackButtonVisible = Microsoft.UI.Xaml.Controls.NavigationViewBackButtonVisible.Visible;
            }

        }

      


    }
}
