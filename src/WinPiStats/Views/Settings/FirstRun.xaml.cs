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
using WinPiStats.Views.Content;
using WinPiStats.Views.MainPage;

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
                
                localSettings.Values["PiHoleServerName"] = serverNameTextBox.Text;
                localSettings.Values["PiHoleAddress"] = serverIPTextBox.Text;
                localSettings.Values["PiHoleAuthKey"] = apiKeyTextBox.Text;
                localSettings.Values["First_Run"] = false;

                this.Frame.Navigate(typeof(MainPage.MainPage));

                




            }    
        }

        
    }
}
