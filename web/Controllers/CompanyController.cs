using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace web.Controllers
{
    [ApiController]
    [Route("/companies")]
    public class CompanyController : ControllerBase
    {
        [HttpPost]
        public async Task<Company_Reply> Create([FromBody] Company_Body body)
        {
            var channel = GrpcChannel.ForAddress("http://localhost:5005");
            var client = new company.companyClient(channel);
            var reply = await client.CreateAsync(new CreateRequest()
            {
                Id = body.Id,
                Name = body.Name
            });
            return new Company_Reply()
            {
                CreatedAt = reply.CreatedAt.ToDateTime(),
                Uid = reply.Uid
            };
        }

        public class Company_Body
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Company_Reply
        {
            public string Uid { get; set; }
            public DateTime CreatedAt { get; set; }
        }
    }
}
