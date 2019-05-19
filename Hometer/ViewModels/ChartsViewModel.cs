// -----------------------------------------------------------------------
// <cleanup>
// Last Cleanup Code: 19.05.2019 14:24
// </cleanup>
// -----------------------------------------------------------------------

#region

using System.Collections.Generic;
using System.Windows.Input;
using Hometer.Api;
using Hometer.Rest;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;
using Entry = Microcharts.Entry;

#endregion

namespace Hometer.ViewModels
{
    public class ChartsViewModel : BaseViewModel
    {
        #region Fields

        private LineChart temperatureChart;

        private List<Entry> temperatureEntries = new List<Entry>();

        #endregion

        #region  Properties

        public ICommand RefreshCommand { get; set; }

        public LineChart TemperatureChart
        {
            get { return temperatureChart; }
            set
            {
                temperatureChart = value;
                OnPropertyChanged(nameof(TemperatureChart));
            }
        }

        #endregion

        #region  Constructors

        public ChartsViewModel()
        {
            RefreshCommand = new Command(RefreshChartValues);

            TemperatureChart = new LineChart
            {
                LineMode = LineMode.Straight, LineSize = 8, LabelTextSize = 26, Entries = temperatureEntries,
                MinValue = 12
            };
            RefreshChartValues();
        }

        #endregion

        #region Public Methods

        public void RefreshChartValues()
        {
            var test = new TemperatureApi(new HometerClient()).GetLastTemperaturesWithLimit(5);

            test.ForEach(e => temperatureEntries.Add(new Entry((float) e.Value)
                {ValueLabel = e.Value.ToString(), Color = SKColors.Red}));
            OnPropertyChanged(nameof(TemperatureChart));
        }

        #endregion
    }
}
