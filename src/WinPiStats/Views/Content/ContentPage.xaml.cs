using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using WinPiStats.Controls.Json;
using WinPiStats.Controls.Settings;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WinPiStats.Views.Content
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ContentPage : Page
    {

        private string piholeServerNumber;
        private PiHoleSettings piHoleSettings;
        
        
        

        public ContentPage()
        {
            
            InitializeComponent();
           

            
            

           
                
        }


        private void PiholeStateCheck()
        {

            var piholeapi = new PiHoleAPI(piHoleSettings.piHoleAddress, piHoleSettings.piHoleAuthKey);
            if (piholeapi.Is_Pihole_Enabled())
            {
                
                GreenDot.Visibility = Visibility.Visible;
                RedDot.Visibility = Visibility.Collapsed;
                toggleStateButton.Content = "Disable";
            }
            else
            {
               
                GreenDot.Visibility = Visibility.Collapsed;
                RedDot.Visibility = Visibility.Visible;
                toggleStateButton.Content = "Enable";
            }


        }

        private void toggleStateButton_Click(object sender, RoutedEventArgs e)
        {
            var piholeapi = new PiHoleAPI(piHoleSettings.piHoleAddress, piHoleSettings.piHoleAuthKey);

            if (piholeapi.Is_Pihole_Enabled())
                piholeapi.Pihole_Change_State("disable");
            else
                piholeapi.Pihole_Change_State("enable");

            PiholeStateCheck();

            
        }

        private void UpdatePiInfo()
        {

            var piholeapi = new PiHoleAPI(piHoleSettings.piHoleAddress, piHoleSettings.piHoleAuthKey);

            blockedTextBlock.Text = piholeapi.Query_Pihole_Domains();
            queriesTodayTextBlock.Text = piholeapi.Total_Queries_Today();
            piholeNameTextBlock.Text = piHoleSettings.piHoleName;
            AdsBlockedTextBlock.Text = piholeapi.Ads_Blocked();
            PercentAdsBlockedTextBlock.Text = piholeapi.Ads_Percent_Blocked() + "%";
            TopItemsTextBlock.Text = piholeapi.topItems();
            LastBlockTextBlock.Text = piholeapi.Most_Recent_Blocked();
            TopClientsTextBlock.Text = piholeapi.topClients();

           
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            piholeServerNumber = e.Parameter as string;


        }

        

        private void Page_Loading(FrameworkElement sender, object args)
        {

           
            piHoleSettings = new PiHoleSettings(piholeServerNumber);
            UpdatePiInfo();

            PiholeStateCheck();

        }

      
    }
}
