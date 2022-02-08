using CUNA.Documents.Service.Controllers;
using CUNA.Documents.Service.Models;
using Newtonsoft.Json;
using System;
using Xunit;

namespace CUNA.Documents.Service.Tests
{
    public class ServiceControllerTest
    {
        public static Guid id = Guid.NewGuid();

        public static ServiceController controller = new(); 

        public static Payload payload = new Payload()
        {
            Callback = $"/callback/{id}"
        };

        [Fact]
        public async void ReturnsParamInput()
        {
            var response = await controller.Post(id);
            Assert.Equal(payload.Callback, response.Value.Callback);
        }
    }
}
