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
using WinPiStats.Controls.Settings;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WinPiStats.Views.Settings
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {

        private PiHoleSettingsStore piholesettingsstore;
        private PiHoleServerInfo piholeserverinfo;
        private ServerCount numPiHoleServers = new ServerCount();
        private int index;
        private bool addNew = false;
        List<string> serversList = new List<string>();


        public SettingsPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loading(FrameworkElement sender, object args)
        {
            Build_Server_List();
            

        }

        private void piServerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            index = piServerList.SelectedIndex + 1;
            modifyButton.IsEnabled = true;
            deleteButton.IsEnabled = true;

            //contentFrame.Navigate(typeof(ModifyServer), index.ToString());
            //SettingSplitView.IsPaneOpen = true;


        }

        private void modifyButton_Click(object sender, RoutedEventArgs e)
        {
            piholesettingsstore = new PiHoleSettingsStore(index.ToString());
            piholeserverinfo = piholesettingsstore.Retrive_Settings();
            serverNameBox.Text = piholeserverinfo.PiHoleServerName;
            serverAddressBox.Text = piholeserverinfo.PiHoleServerAddress;
            serverAuthBox.Text = piholeserverinfo.PiHoleServerAuthKey;
            addModifyBlock.Text = "Modify Server:";
            addNew = false;
            SettingSplitView.IsPaneOpen = true;


            

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            
            SettingSplitView.IsPaneOpen = false;
            

        }


        private void SettingSplitView_LostFocus(object sender, RoutedEventArgs e)
        {
            
           // SettingSplitView.IsPaneOpen = false;
            
        }


        private void Build_Server_List()
        {
            for (var i = 1; i <= Convert.ToInt32(numPiHoleServers.NumberOfServers); i++)
            {
                piholesettingsstore = new PiHoleSettingsStore(i.ToString());
                piholeserverinfo = new PiHoleServerInfo();
                piholeserverinfo = piholesettingsstore.Retrive_Settings();
                serversList.Add(piholeserverinfo.PiHoleServerName);


            }

            piServerList.ItemsSource = serversList;
        }

        private void addNewButton_Click(object sender, RoutedEventArgs e)
        {
            addNew = true;
            addModifyBlock.Text = "Add A New Server:";
            SettingSplitView.IsPaneOpen = true;
        }
    }
}
