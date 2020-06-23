using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinPiStats.Controls.Settings;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WinPiStats.Views.Settings
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FirstRun : Page
    {
        
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

                var piholesettings = new PiHoleSettingsStore("1");
                var piholeinfo = new PiHoleServerInfo();
                var firstrun = new AppFirstRun();
                piholeinfo.PiHoleServerName = serverNameTextBox.Text;
                piholeinfo.PiHoleServerAuthKey = apiKeyTextBox.Text;
                piholeinfo.PiHoleServerAddress = serverIPTextBox.Text;

                piholesettings.Save_Settings(piholeinfo);
                firstrun.FirstRun = false;


               // var settingsStore = new SettingsStore("1");

               // settingsStore.Store_Settings(serverNameTextBox.Text, apiKeyTextBox.Text, serverIPTextBox.Text);


                //settingsStore.First_Run(false);

                this.Frame.Navigate(typeof(MainPage.MainPage));

                




            }    
        }

        
    }
}
