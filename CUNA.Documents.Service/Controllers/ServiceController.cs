using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CUNA.Documents.Service.Models;
using CUNA.Documents.Service.ThirdParty;
using System.Net.Http;

namespace CUNA.Documents.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        // Post a request
        [Route("/request")]
        [HttpPost]
        public async Task<ActionResult<string>> Post(string body)
        {
            // prepare the request payload

            Guid newId = Guid.NewGuid();
            Payload requestPayload = new Payload {
                Body = body,
                CreatedAt = DateTime.Now,
                Id = newId,
                Callback = $"/callback/{newId}"
            };

            // invoke the client request to the third-party service
            try
            {
                HttpResponseMessage response = await ThirdPartyClient.ServiceRequest(requestPayload);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                return e.Message;
            }
        }

        // Post a callback
        [Route("/callback")]
        [HttpPost]
        public async Task<ActionResult<Payload>> Post(Guid id)
        {
            return new Payload()
            {
                Callback = null
            };
        }

        // Update a callback status
        [Route("/callback/{id}")]
        [HttpPut]
        public async Task<ActionResult<Payload>> Put()
        {
            return new Payload
            {
                Status = "PROCESSED",
                Detail = "This order is in process"
            };
        }

        // Get status
        [Route("/callback/{id}")]
        [HttpGet]
        public async Task<ActionResult<Payload>> Get()
        {
            return new Payload
            {
                Status = "COMPLETED",
                Detail = "This order has been gotten"
            };
        }
    }
}
