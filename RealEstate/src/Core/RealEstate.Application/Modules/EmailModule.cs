using Autofac;
using Microsoft.Extensions.Configuration;
using RealEstate.Application.Contracts;
using RealEstate.Application.Implementations;
using RealEstate.Domain.Configurations;

namespace RealEstate.Application.Modules
{
    class EmailModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<EmailService>().As<IEmailService>().SingleInstance();

            builder.Register(c => c.Resolve<IConfiguration>()
                  .GetSection(nameof(EmailServiceOptions)).Get<EmailServiceOptions>()
                   ?? throw new InvalidOperationException())
                  .AsSelf()
                  .SingleInstance(); //Singleton 
        }
    }
}
