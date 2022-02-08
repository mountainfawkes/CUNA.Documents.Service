using CUNA.Documents.Service.Models;
using CUNA.Documents.Service.ThirdParty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CUNA.Documents.Service.Tests
{
    public class ThirdPartyClientTest
    {
        static public Guid id = Guid.NewGuid();

        static Payload payload = new Payload
        {
            Body = "This is a sample payload",
            Id = id,
            Callback = $"/callback/{id}"
        };

        [Fact]
        public async void QueryFail()
        {
            var response = await ThirdPartyClient.ServiceRequest(payload);
            Assert.False(response.IsSuccessStatusCode);
        }
    }
}
