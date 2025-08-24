using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Contracts;
using RealEstate.Application.Implementations;
using RealEstate.Application.Repositories;
using RealEstate.Domain.Configurations;
using RealEstate.Persistence;
using RealEstate.Persistence.Repositories;

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
            builder.Services.AddControllers();

            builder.Services.AddDbContext<DbContext, DataContext>();
            builder.Services.AddScoped<ICityRepository, CityRepository>();
            builder.Services.AddSingleton<IDateTimeService, LocalDateTimeService>();
            builder.Services.AddSingleton<IOtpService, OtpService>();
            builder.Services.Configure<OtpServiceOptions>(cfg =>
            {
                cfg.Host = "https://platform.clickatell.com";
                cfg.EndPoint = "messages/http/send";
                cfg.ApiKey = "oeqPQO-3TOCT69vWucSepg==";
            });

            builder.Services.Configure<EmailServiceOptions>(cfg =>
            {
                cfg.Host = "smtp@mail.ru";
                cfg.Port = 465;
                cfg.EnableSsl = true;
                cfg.DisplayName = "Mir";
                cfg.Username = "username";
                cfg.Password = "password";
            }).AddSingleton<IEmailService, EmailService>();
            //builder.Services.AddDbContext<DataContext>(cfg =>
            //{
            //    cfg.UseSqlServer("Data Source=Localhost;Initial Catalog=RealEstate;Integrated Security=True;Encrypt=False", sqlServerOptions =>
            //    {
            //        sqlServerOptions.CommandTimeout(15);
            //        sqlServerOptions.MigrationsHistoryTable("MigrationHistory");
            //    });
            //});
            var app = builder.Build();

            app.MapControllers();
            app.Run();
        }
    }
}
