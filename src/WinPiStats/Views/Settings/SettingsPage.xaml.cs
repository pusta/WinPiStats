using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinPiStats.Controls.Settings;
using WinPiStats.Models;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WinPiStats.Views.Settings
{
    
    public sealed partial class SettingsPage : Page
    {

        //private PiHoleSettingsStore piholesettingsstore;
        private PiHoleServerInfo piholeserverinfo = new PiHoleServerInfo();
        private ServerCount numPiHoleServers = new ServerCount();
        //private int index;
        private bool addNew = false;
        public ListViewModel ViewModel { get; set; }
        //List<string> serversList = new List<string>();

        

        public SettingsPage()
        {
            this.InitializeComponent();
            this.ViewModel = new ListViewModel();
            
            
        }

        

        private void Page_Loading(FrameworkElement sender, object args)
        {
            
            

        }

     

        private void modifyButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (settingListView.SelectedIndex != -1)
            { 
            addNew = false;
            SettingSplitView.IsPaneOpen = true;
            }






        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

  


        private void SettingSplitView_LostFocus(object sender, RoutedEventArgs e)
        {

             //SettingSplitView.IsPaneOpen = false;
            


        }


        /*private void Build_Server_List()
        {
            for (var i = 1; i <= Convert.ToInt32(numPiHoleServers.NumberOfServers); i++)
            {
                piholesettingsstore = new PiHoleSettingsStore(i.ToString());
                piholeserverinfo = new PiHoleServerInfo();
                piholeserverinfo = piholesettingsstore.Retrive_Settings();
                serversList.Add(piholeserverinfo.PiHoleServerName);


            }

           // piServerList.ItemsSource = serversList;
        } */

        private void addNewButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            
            SettingSplitView.IsPaneOpen = false;
        }

        

       
    }
}
