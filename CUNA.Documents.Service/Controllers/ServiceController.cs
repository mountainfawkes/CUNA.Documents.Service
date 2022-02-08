using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CUNA.Documents.Service.Models;
using CUNA.Documents.Service.ThirdParty;

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
            Guid newId = Guid.NewGuid();
            Payload requestPayload = new Payload {
                Body = body,
                CreatedAt = DateTime.Now,
                Id = newId,
            };

            try
            {
                string response = await ThirdPartyClient.ServiceRequest(requestPayload);
                return response;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Post a callback
        [Route("/callback")]
        [HttpPost]
        public async Task<ActionResult<Payload>> Post(Guid id)
        {
            return new Payload
            {
                Status = "STARTED"
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
