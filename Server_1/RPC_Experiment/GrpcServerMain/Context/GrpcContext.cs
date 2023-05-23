using Microsoft.EntityFrameworkCore;

namespace GrpcServerMain.Context
{
    public class GrpcContext : DbContext
    {
        public GrpcContext() : base(new DbContextOptionsBuilder<GrpcContext>().UseInMemoryDatabase("gRPC_db").Options)
        { }

        public GrpcContext(DbContextOptions<GrpcContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
}
