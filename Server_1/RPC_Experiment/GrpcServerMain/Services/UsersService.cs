using Google.Protobuf.WellKnownTypes;

using Grpc.Core;

using GrpcServerMain.Context;

using Microsoft.AspNetCore.Identity;

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

        public override Task<UserListResponse> GetUsers(Empty request, ServerCallContext context)
        {
            var res = new UserListResponse();
            res.Users.AddRange(_context.Users);

            return Task.FromResult(res);
        }

        public override Task<User> GetUser(UserRequest request, ServerCallContext context)
        {
            var res = _context.Users.FirstOrDefault(u => u.Id == request.Id);

            if(res == null) 
            { throw new Exception($"User {request.Id} not found"); }


            return Task.FromResult(res);
        }

        public override Task<User> CreateUser(User request, ServerCallContext context)
        {
            var res = _context.Users.FirstOrDefault(u => u.Id == request.Id);

            if (res != null)
            { throw new Exception($"User {request.Id} exists"); }

            _context.Users.Add(request);
            _context.SaveChanges();


            res = _context.Users.FirstOrDefault(u => u.Id == request.Id);

            return Task.FromResult(res);
        }

        public override Task<CardListResponse> GetUserCards(UserRequest request, ServerCallContext context)
        {
            var db = _context;

            CardListResponse res = new();

            res.Cards.AddRange(db.Cards.Where(c => c.Userid == request.Id));


            return Task.FromResult(res);
        }
    }
}
