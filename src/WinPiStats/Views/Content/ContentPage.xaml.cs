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
using Windows.Storage;
using System.Drawing;
using Windows.Data.Text;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WinPiStats.Views.Content
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ContentPage : Page
    {

        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        private string piholeAuthkey;
        private string piholeAddress;
        private string piholeName;
        private string piholeServerNumber;   
        
        
        

        public ContentPage()
        {
            
            InitializeComponent();
           

            //ReadSettings();
            

           
                
        }


        private void PiholeStateCheck()
        {

            var piholeapi = new PiHoleAPI(piholeAddress, piholeAuthkey);
            if (piholeapi.Is_Pihole_Enabled())
            {
                //isEnabledTextBlock.Text = "Enabled";
                GreenDot.Visibility = Visibility.Visible;
                RedDot.Visibility = Visibility.Collapsed;
                toggleStateButton.Content = "Disable";
            }
            else
            {
               // isEnabledTextBlock.Text = "Disabled";
                GreenDot.Visibility = Visibility.Collapsed;
                RedDot.Visibility = Visibility.Visible;
                toggleStateButton.Content = "Enable";
            }


        }

        private void toggleStateButton_Click(object sender, RoutedEventArgs e)
        {
            var piholeapi = new PiHoleAPI(piholeAddress, piholeAuthkey);

            if (piholeapi.Is_Pihole_Enabled())
                piholeapi.Pihole_Change_State("disable");
            else
                piholeapi.Pihole_Change_State("enable");

            PiholeStateCheck();

            
        }

        private void UpdatePiInfo()
        {

            var piholeapi = new PiHoleAPI(piholeAddress, piholeAuthkey);

            blockedTextBlock.Text = piholeapi.Query_Pihole_Domains();
            queriesTodayTextBlock.Text = piholeapi.Total_Queries_Today();
            piholeNameTextBlock.Text = piholeName;
            AdsBlockedTextBlock.Text = piholeapi.Ads_Blocked();
            PercentAdsBlockedTextBlock.Text = piholeapi.Ads_Percent_Blocked() + "%";
            TopItemsTextBlock.Text = piholeapi.topItems();
            LastBlockTextBlock.Text = piholeapi.Most_Recent_Blocked();
            //LastBlockTextBlock.Text = piholeServerNumber;
            TopClientsTextBlock.Text = piholeapi.topClients();

           
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            piholeServerNumber = e.Parameter as string;





        }

        private void ReadSettings()
        {
            var numPiholes = localSettings.Values["NumberofServers"];

            /*piholeName = localSettings.Values["PiHoleServerName" + '-' + localSettings.Values["NumberofServers"].ToString()].ToString();
            piholeAddress = localSettings.Values["PiHoleAddress" + '-' + localSettings.Values["NumberofServers"].ToString()].ToString();
            piholeAuthkey = localSettings.Values["PiHoleAuthKey" + '-' + localSettings.Values["NumberofServers"].ToString()].ToString();*/

            piholeName = localSettings.Values["PiHoleServerName" + '-' + piholeServerNumber].ToString();
            piholeAddress = localSettings.Values["PiHoleAddress" + '-' + piholeServerNumber].ToString();
            piholeAuthkey = localSettings.Values["PiHoleAuthKey" + '-' + piholeServerNumber].ToString();





        }

        private void Page_Loading(FrameworkElement sender, object args)
        {

            ReadSettings();
            UpdatePiInfo();

            PiholeStateCheck();

        }

      
    }
}
