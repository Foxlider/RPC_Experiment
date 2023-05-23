using Google.Protobuf.WellKnownTypes;

using Grpc.Core;

using GrpcServerMain.Context;

namespace GrpcServerMain.Services
{
    public class BasicService : Basic.BasicBase
    {
        private readonly ILogger<BasicService> _logger;
        private readonly GrpcContext _context;

        public BasicService(ILogger<BasicService> logger, GrpcContext context)
        {
            _logger = logger;
            _context = context;
        }
        public override Task<Pong> Handshake(Empty request, ServerCallContext context)
        {
            return Task.FromResult(new Pong
            { Message = "Pong !" });
        }
    }
}
