using Autofac;
using Microsoft.Extensions.Configuration;
using RealEstate.Application.Contracts;
using RealEstate.Application.Implementations;
using RealEstate.Domain.Configurations;

namespace RealEstate.Application.Modules
{
    class CryptoModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CryptoService>().As<ICryptoService>().SingleInstance();

            builder.Register(c => c.Resolve<IConfiguration>()
            .GetSection(nameof(CryptoServiceOptions)).Get<CryptoServiceOptions>()
             ?? throw new InvalidOperationException())
            .AsSelf()
            .SingleInstance(); //Singleton 
        }
    }
}
