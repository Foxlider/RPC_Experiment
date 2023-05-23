using Google.Protobuf.WellKnownTypes;

using Grpc.Core;

using GrpcServerMain.Context;

namespace GrpcServerMain.Services
{
    public class CardsService : Cards.CardsBase
    {
        private readonly ILogger<CardsService> _logger;
        private readonly GrpcContext _context;

        public CardsService(ILogger<CardsService> logger, GrpcContext context)
        {
            _logger = logger;
            _context = context;
        }

        public override Task<CardListResponse> GetAvailableCards(Empty request, ServerCallContext context)
        {
            var db = new GrpcContext();

            CardListResponse res = new();
            res.Cards.AddRange(db.Cards.Where(c=> c.Userid == -1));

            return Task.FromResult(res);
        }

        

    }
}
