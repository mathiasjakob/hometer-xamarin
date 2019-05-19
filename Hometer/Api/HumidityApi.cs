// -----------------------------------------------------------------------
// <cleanup>
// Last Cleanup Code: 16.05.2019 23:21
// </cleanup>
// -----------------------------------------------------------------------

using Hometer.Models;
using Hometer.Rest;
using RestSharp;

namespace Hometer.Api
{
    public class HumidityApi
    {
        /// <summary>
        ///     Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public HometerClient HometerClient { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="HumidityApi" /> class.
        /// </summary>
        /// <returns></returns>
        public HumidityApi(HometerClient hometerClient)
        {
            HometerClient = hometerClient;
        }

        /// <summary>
        ///     Get the current temperature
        /// </summary>
        /// <returns>Temperature</returns>
        public Humidity GetCurrentHumidity()
        {
            var request = new RestRequest("humidity", Method.GET);
            var response = HometerClient.RestClient.Execute<Humidity>(request);

            return response.Data;
        }
    }
}
