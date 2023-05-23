using Grpc.Core;

using GrpcServerMain;

namespace GrpcServerMain.Services
{
    public class GreeterService : Greeter.GreeterBase
    {

        public List<CardResponse> CardResponses { get; set; }

        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
            CardResponses = new List<CardResponse>()
            {
                new CardResponse() { Cardid = 1},
                new CardResponse() { Cardid = 2},
                new CardResponse() { Cardid = 3}
            };
        }

        public override Task<Pong> Handshake(Ping request, ServerCallContext context)
        {
            return Task.FromResult(new Pong
            {
                Message = "Pong " + request.Name
            });
        }


        public override Task<CardListResponse> GetAvailableCards(Empty request, ServerCallContext context) {

            return Task.FromResult( new CardListResponse{
            });
        }

        public override Task<TransactionListResponse> GetUserTransactions(UserRequest request, ServerCallContext context) {
        
            return Task.FromResult( new TransactionListResponse{
            });
        }

        public override Task<CardResponse> BuyCard(CardRequest request, ServerCallContext context) {
        
            return Task.FromResult( new CardResponse{
                Cardid = request.Cardid,
            });
        }


        public override Task<CardResponse> SellCard(CardRequest request, ServerCallContext context) { 
            


            return Task.FromResult( new CardResponse{
                Cardid = request.Cardid,
            });
        } 


    }
}