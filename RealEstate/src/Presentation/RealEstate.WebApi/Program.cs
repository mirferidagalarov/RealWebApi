using Microsoft.EntityFrameworkCore;
using RealEstate.Persistence;

namespace RealEstate.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
             ORM,Entity FrameworkCore,DbContext

            Object Relational Mapping
             */



            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddDbContext<DataContext>(cfg =>
            //{
            //    cfg.UseSqlServer("Data Source=Localhost;Initial Catalog=RealEstate;Integrated Security=True;Encrypt=False", sqlServerOptions =>
            //    {
            //        sqlServerOptions.CommandTimeout(15);
            //        sqlServerOptions.MigrationsHistoryTable("MigrationHistory");
            //    });
            //});
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
