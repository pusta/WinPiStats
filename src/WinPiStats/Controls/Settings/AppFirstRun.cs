using Windows.Storage;

namespace WinPiStats.Controls.Settings
{
    class AppFirstRun
    {
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public bool FirstRun {
            get
            {
                return (bool)localSettings.Values["First_Run"];
            }
            set
            {
                localSettings.Values["First_Run"] = value;

            }
        
        
        
        
        
        
        
        
        
        
        
        
        
        }
    }
}
