// -----------------------------------------------------------------------
// <cleanup>
// Last Cleanup Code: 17.05.2019 13:23
// </cleanup>
// -----------------------------------------------------------------------

using Hometer.Models;
using Hometer.Rest;
using RestSharp;

namespace Hometer.Api
{
    public class PressureApi
    {
        /// <summary>
        ///     Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public HometerClient HometerClient { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PressureApi" /> class.
        /// </summary>
        /// <returns></returns>
        public PressureApi(HometerClient hometerClient)
        {
            HometerClient = hometerClient;
        }

        /// <summary>
        ///     Get the current temperature
        /// </summary>
        /// <returns>Temperature</returns>
        public Pressure GetCurrentPressure()
        {
            var request = new RestRequest("pressure", Method.GET);
            var response = HometerClient.RestClient.Execute<Pressure>(request);

            return response.Data;
        }
    }
}
