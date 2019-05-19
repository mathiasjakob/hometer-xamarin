// -----------------------------------------------------------------------
// <cleanup>
// Last Cleanup Code: 17.05.2019 13:36
// </cleanup>
// -----------------------------------------------------------------------

using Xamarin.Forms;

namespace Hometer.ViewModels
{
    public class SettingsViewModel
    {
        public string IP
        {
            get
            {
                return Application.Current.Properties["ip"].ToString(); 
            }
            set { Application.Current.Properties["ip"] = value; }
        }

        public SettingsViewModel()
        {
            // If ip key is not present create it
            if (!Application.Current.Properties.ContainsKey("ip"))
            {
                Application.Current.Properties.Add("ip", string.Empty);
            }
        }
    }
}
