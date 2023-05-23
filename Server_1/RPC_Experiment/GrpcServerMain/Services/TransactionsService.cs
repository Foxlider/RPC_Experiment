using Grpc.Core;

using GrpcServerMain.Context;

namespace GrpcServerMain.Services
{
    public class TransactionsService : Transactions.TransactionsBase
    {
        private readonly ILogger<TransactionsService> _logger;
        private readonly GrpcContext _context;

        public TransactionsService(ILogger<TransactionsService> logger, GrpcContext context)
        {
            _logger = logger;
            _context = context;
        }

        public override Task<TransactionListResponse> GetUserTransactions(UserRequest request, ServerCallContext context)
        {
            var db = new GrpcContext();

            TransactionListResponse res = new();
            res.Transactions.AddRange(db.Transactions.Where(t => t.UserId == request.Id));

            return Task.FromResult(res);
        }


        public override Task<Card> BuyCard(TransactionRequest request, ServerCallContext context)
        {
            var db = new GrpcContext();

            var card = db.Cards.FirstOrDefault(c => c.Id == request.Cardid);

            if (card == null)
                throw new Exception($"Card {request.Cardid} not found");

            db.Transactions.Add(new Transaction() { 
                CardId = request.Cardid, 
                UserId = request.Userid, 
                Id = db.Transactions.Count(),
                Type = TransactionType.Buy
            });

            card.Userid = request.Userid;

            db.SaveChanges();

            return Task.FromResult(card);
        }


        public override Task<Card> SellCard(TransactionRequest request, ServerCallContext context)
        {

            var db = new GrpcContext();

            var card = db.Cards.FirstOrDefault(c => c.Id == request.Cardid);

            if (card == null)
                throw new Exception($"Card {request.Cardid} not found");

            db.Transactions.Add(new Transaction() { 
                CardId = request.Cardid, 
                UserId = request.Userid, 
                Id = db.Transactions.Count(),
                Type = TransactionType.Sell
            });

            card.Userid = -1;

            db.SaveChanges();

            return Task.FromResult(card);
        }


    }
}
