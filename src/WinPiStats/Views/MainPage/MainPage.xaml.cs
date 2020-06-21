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
using WinPiStats.Controls.Json;
using WinPiStats.Views.Content;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;





// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WinPiStats.Views.MainPage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    

    public sealed partial class MainPage : Page
    {
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        public MainPage()
        {
            this.InitializeComponent();
           Render_Menu();
            //Load_Content();
            
            
            
            
           
            

              



            
        }

     

        private void Page_Loading(FrameworkElement sender, object args)
        {
            //read settings
           ReadSettings();
            
        }

        private void Render_Menu()
        {

            mainNav.MenuItems.Add(new Microsoft.UI.Xaml.Controls.NavigationViewItemSeparator());
            var numServers = Convert.ToInt32(localSettings.Values["NumberofServers"]);
            var uriImage = "ms-appx:///Assets/pilogo.png";
            var uri = new Uri(uriImage);
            var piIcon = new BitmapIcon();
            piIcon.UriSource = uri;

            for (var i = 0; i < numServers; i++)
            {
                Microsoft.UI.Xaml.Controls.NavigationViewItem newMenu = new Microsoft.UI.Xaml.Controls.NavigationViewItem();
                newMenu.Content = localSettings.Values["PiHoleServerName" + '-' + localSettings.Values["NumberofServers"].ToString()];
                newMenu.Icon = piIcon;

                mainNav.MenuItems.Add(newMenu);


            }
 





        }

        private void ReadSettings()
        {
            
           
           

        }

        /*public async  void PullPiHoleJson()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://192.168.113.10/admin/api.php?summary");

            var stringData = response.Content.ReadAsStringAsync().Result;

            var rootObject = JsonObject.Parse(stringData);

            blockedTextbox.Text = rootObject["domains_being_blocked"].ToString().Trim('"');



        }*/


      

        public void Load_Content()
        {

            contentFrame.Navigate(typeof(ContentPage));

        }

        private void mainNav_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {

            if (args.IsSettingsSelected)
            {
                contentFrame.Navigate(typeof(SettingsPage));
                
                
            }
            else
            {
                var selectedItem = (Microsoft.UI.Xaml.Controls.NavigationViewItem)args.SelectedItem;
                if (selectedItem != null)
                {
                    string selectedItemTag = ((string)selectedItem.Tag);
                    //sender.Header = "Sample Page " + selectedItemTag.Substring(selectedItemTag.Length - 1);
                   // string pageName = "WinPiStats.Views.Content." + selectedItemTag;
                    //Type pageType = Type.GetType(pageName);
                    contentFrame.Navigate(typeof(ContentPage));


                }






            }

        }

      


    }
}
