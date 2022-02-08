using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CUNA.Documents.Service.Models;

namespace CUNA.Documents.Service.ThirdParty
{
    public class ThirdPartyClient
    {
        /*
        
        Ordinarily, I'd use this opportunity to build a more robust HttpClient instance to build and query the third-party service.
        We'll be stubbing our calls today. Since we invoke HttpClient requests with a function, I'll use functions here to 
        stub the client response. For the purpose of this exercise, we should assume that calls would be made to http://example.com.

        A more typical client request would have the following characteristics:

        - A bearer token, either queried from a configuration endpoint or stored in a web.config file or environment variable
        - Static field for the base endpoint (in this case, http://example.com/request)
        - Instance invocation of a client; I would use the native HttpClient, but there are many alternatives
        - Serialization of the request body, either natively or with a NuGet package like Newtonsoft
        - Async invocation of client query with requisite headers, including necessary authorization tokens or keys
        - Check for successful response code

        */

        private static string requestUri = "http://example.com/request";
        private static HttpClient client = new HttpClient();

        public static async Task<HttpResponseMessage> ServiceRequest(Payload payload)
        {
            // serialize the request
            var content = new StringContent(JsonSerializer.Serialize(payload));

            // query the third-party endpoint
            var response = await client.PostAsync(requestUri, content);

            return response;
        }
    }
}
