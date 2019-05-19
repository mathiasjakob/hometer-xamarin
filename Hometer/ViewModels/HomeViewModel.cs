// -----------------------------------------------------------------------
// <cleanup>
// Last Cleanup Code: 16.05.2019 22:09
// </cleanup>
// -----------------------------------------------------------------------

using System.Diagnostics;
using System.Threading.Tasks;
using Hometer.Api;
using Hometer.Rest;

namespace Hometer.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        
        private string temperatureString;
        
        private string humidityString;
        
        private string pressureString;

        public string TemperatureString
        {
            get { return temperatureString; }
            set
            {
                temperatureString = value;
                OnPropertyChanged(nameof(TemperatureString));
            }
        }

        public string HumidityString
        {
            get { return humidityString; }
            set
            {
                humidityString = value;
                OnPropertyChanged(nameof(HumidityString));
            }
        }

        public string PressureString
        {
            get { return pressureString; }
            set
            {
                pressureString = value; 
                OnPropertyChanged(nameof(PressureString));
            }
        }

        public HomeViewModel()
        {
            var client = new HometerClient();
            var temperatureApi = new TemperatureApi(client);
            var humidityApi = new HumidityApi(client);
            var pressureApi = new PressureApi(client);

            var task = new Task(async () =>
            {
                while (true)
                {
                    TemperatureString = temperatureApi.GetCurrentTemperatureAsString();
                    HumidityString = humidityApi.GetCurrentHumidity().Value.ToString();
                    PressureString = pressureApi.GetCurrentPressure().Value.ToString();
                    Debug.WriteLine("Test");
                    await Task.Delay(5000);
                }
            });
            task.Start(); 
        }
    }
}
