using System;
using System.Threading.Tasks;
using CUNA.Documents.Service.Models;

namespace CUNA.Documents.Service.ThirdParty
{
    public class ThirdPartyClient
    {
        /* Ordinarily, I'd use this opportunity to build a more robust HttpClient instance to build and query the third-party service.
        We'll be stubbing our calls today. Since we invoke HttpClient requests with a function, I'll use functions here to 
        stub the client response. For the purpose of this exercise, we should assume that calls would be made to http://example.com. */

        public static async Task<string> ServiceRequest(Payload payload)
        {
            payload.Callback = $"/callback/{payload.Id}";
            return payload.Body;
        }
    }
}
