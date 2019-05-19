// -----------------------------------------------------------------------
// <cleanup>
// Last Cleanup Code: 16.05.2019 22:35
// </cleanup>
// -----------------------------------------------------------------------

using RestSharp;

namespace Hometer.Rest
{
    public class HometerClient
    {
        private string baseUrl = "http://192.168.2.123:9500/v1/";

        public RestClient RestClient;
        
        public HometerClient()
        {
            RestClient = new RestClient(baseUrl);
        }
    }
}
