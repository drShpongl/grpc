using System;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace host
{
    public class CompanyService : company.companyBase
    {
        private readonly ILogger<CompanyService> _logger;
        public CompanyService(ILogger<CompanyService> logger)
        {
            _logger = logger;
        }

        public override Task<CreateReply> Create(CreateRequest request, ServerCallContext context)
        {
            return Task.FromResult(new CreateReply
            {
                Id = request.Id ?? 0,
                Name = request.Name,
                CreatedAt = Timestamp.FromDateTime(DateTime.UtcNow),
                Uid = Guid.NewGuid().ToString()
            });
        }
    }
}
