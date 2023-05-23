using GrpcServerMain.Context;
using GrpcServerMain.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

using System.Reflection.Metadata;

namespace GrpcServerMain
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddGrpcReflection();

            // Additional configuration is required to successfully run gRPC on macOS.
            // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

            // Add services to the container.
            builder.Services.AddGrpc();
            var options = new DbContextOptionsBuilder<GrpcContext>().UseInMemoryDatabase("gRPC_db").Options;
            builder.Services.AddDbContext<GrpcContext>(options => 
                options.UseInMemoryDatabase("gRPC_db"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.MapGrpcService<BasicService>();
            app.MapGrpcService<CardsService>();
            app.MapGrpcService<TransactionsService>();
            app.MapGrpcService<UsersService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
            
            IWebHostEnvironment env = app.Environment;
            if (env.IsDevelopment())
            {
                app.MapGrpcReflectionService();
            }

            using (var context = new GrpcContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                if (!context.Cards.Any())
                {
                    context.Cards.Add(new Card { Id = 1, Attack = 10, Defense = 10, HealthPoints = 100, Name = "Debug1", Userid = -1 });
                    context.Cards.Add(new Card { Id = 2, Attack = 10, Defense = 10, HealthPoints = 100, Name = "Debug2", Userid = -1 });
                    context.Cards.Add(new Card { Id = 3, Attack = 10, Defense = 10, HealthPoints = 100, Name = "Debug3", Userid = -1 });
                    context.Cards.Add(new Card { Id = 4, Attack = 10, Defense = 10, HealthPoints = 100, Name = "Debug4", Userid = -1 });
                    context.Cards.Add(new Card { Id = 5, Attack = 10, Defense = 10, HealthPoints = 100, Name = "Debug5", Userid = -1 });
                }

                context.SaveChanges();
            }

            app.Run();
        }
    }
}