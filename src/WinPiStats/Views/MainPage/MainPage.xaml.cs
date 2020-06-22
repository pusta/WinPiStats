using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinPiStats.Views.Settings;
using WinPiStats.Views.Content;
using WinPiStats.Controls.Settings;





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
           Render_Menu();
            //Load_Content();
            
            
            
            
           
            

              



            
        }

     

 

        private void Render_Menu()
        {

            var settingsStore = new SettingsStore();
            mainNav.MenuItems.Add(new Microsoft.UI.Xaml.Controls.NavigationViewItemSeparator());
            var numServers = Convert.ToInt32(settingsStore.Number_of_Servers());
            var uriImage = "ms-appx:///Assets/pilogo.png";
            var uri = new Uri(uriImage);
            var piIcon = new BitmapIcon();
            piIcon.UriSource = uri;

            for (var i = 1; i <= numServers; i++)
            {
                Microsoft.UI.Xaml.Controls.NavigationViewItem newMenu = new Microsoft.UI.Xaml.Controls.NavigationViewItem();
                var piHoleSettings = new PiHoleSettings(i.ToString());
                newMenu.Content = piHoleSettings.piHoleName;
                newMenu.Tag = i.ToString();
                newMenu.Icon = piIcon;

                mainNav.MenuItems.Add(newMenu);


            }
 





        }

     

           

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
                    contentFrame.Navigate(typeof(ContentPage), selectedItemTag);


                }






            }

        }

      


    }
}
