using Grpc.Core;

using GrpcServerMain.Context;

namespace GrpcServerMain.Services
{
    public class UsersService : Users.UsersBase
    {
        private readonly ILogger<UsersService> _logger;
        private readonly GrpcContext _context;

        public UsersService(ILogger<UsersService> logger, GrpcContext context)
        {
            _logger = logger;
            _context = context;
        }


        public override Task<CardListResponse> GetUserCards(UserRequest request, ServerCallContext context)
        {
            var db = new GrpcContext();

            CardListResponse res = new();

            res.Cards.AddRange(db.Cards.Where(c => c.Userid == request.Id));


            return Task.FromResult(res);
        }
    }
}
