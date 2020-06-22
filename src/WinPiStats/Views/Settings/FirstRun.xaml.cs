using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WinPiStats.Views.Settings
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FirstRun : Page
    {
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        public FirstRun()
        {
            this.InitializeComponent();
        }

        private void saveSettings_Click(object sender, RoutedEventArgs e)
        {
            errorTextBlock.Visibility = Visibility.Collapsed;

            if (String.IsNullOrWhiteSpace(serverNameTextBox.Text) || String.IsNullOrWhiteSpace(serverIPTextBox.Text) || String.IsNullOrWhiteSpace(apiKeyTextBox.Text))
            {

                errorTextBlock.Text = "All fields above are required.";
                
                errorTextBlock.Visibility = Visibility.Visible;



            }

            else
            {

                localSettings.Values["NumberofServers"] = 1;

                //reserved for multi-pihole support
                localSettings.Values["PiHoleServerName" + '-' + localSettings.Values["NumberofServers"].ToString()] = serverNameTextBox.Text;
                localSettings.Values["PiHoleAddress" + '-' + localSettings.Values["NumberofServers"].ToString()] = serverIPTextBox.Text;
                localSettings.Values["PiHoleAuthKey" + '-' + localSettings.Values["NumberofServers"].ToString()] = apiKeyTextBox.Text;

                //Single PiHole Support
                //localSettings.Values["PiHoleServerName"] = serverNameTextBox.Text;
                //localSettings.Values["PiHoleAddress"] = serverIPTextBox.Text;
                //localSettings.Values["PiHoleAuthKey"] = apiKeyTextBox.Text;

                localSettings.Values["First_Run"] = false;

                this.Frame.Navigate(typeof(MainPage.MainPage));

                




            }    
        }

        
    }
}
