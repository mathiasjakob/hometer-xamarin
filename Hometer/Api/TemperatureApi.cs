// -----------------------------------------------------------------------
// <cleanup>
// Last Cleanup Code: 17.05.2019 14:00
// </cleanup>
// -----------------------------------------------------------------------

#region

using System;
using System.Collections.Generic;
using Hometer.Models;
using Hometer.Rest;
using RestSharp;

#endregion

namespace Hometer.Api
{
    /// <summary>
    ///     Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class TemperatureApi
    {
        #region  Properties

        /// <summary>
        ///     Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public HometerClient HometerClient { get; set; }

        #endregion

        #region  Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="TemperatureApi" /> class.
        /// </summary>
        /// <returns></returns>
        public TemperatureApi(HometerClient hometerClient)
        {
            HometerClient = hometerClient;
        }

        #endregion

        #region Public Methods

        public string GetCurrentTemperatureAsString()
        {
            try
            {
                var temperature = GetCurrentTemperature();
                return temperature == null ? "-" : temperature.Value.ToString();
            }
            catch (Exception e) { return "-"; }
        }


        /// <summary>
        ///     Get the current temperature
        /// </summary>
        /// <returns>Temperature</returns>
        public Temperature GetCurrentTemperature()
        {
            var request = new RestRequest("temperature", Method.GET);
            var response = HometerClient.RestClient.Execute<Temperature>(request);
            return response.Data;
        }

        /// <summary>
        ///     Get the last temperature values with limit
        /// </summary>
        /// <param name="limit">Limit</param>
        /// <returns>List&lt;Temperature&gt;</returns>
        public List<Temperature> GetLastTemperaturesWithLimit(int? limit)
        {
            try { 
                var request = new RestRequest("temperatures/" + limit, Method.GET);
                var response = HometerClient.RestClient.Execute<List<Temperature>>(request);
                return response.Data;  
            }
            catch (Exception e)
            {
                return new List<Temperature>();
            }
        }

        #endregion
    }
}
