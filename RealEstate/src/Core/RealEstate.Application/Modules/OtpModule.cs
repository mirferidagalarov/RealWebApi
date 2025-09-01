using Autofac;
using Microsoft.Extensions.Configuration;
using RealEstate.Application.Contracts;
using RealEstate.Application.Implementations;
using RealEstate.Domain.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Modules
{
     class OtpModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OtpService>().As<IOtpService>().SingleInstance();


            builder.Register(c => c.Resolve<IConfiguration>()
            .GetSection(nameof(OtpServiceOptions)).Get<OtpServiceOptions>()
             ?? throw new InvalidOperationException())
            .AsSelf()
            .SingleInstance(); //Singleton 
        }
    }
}
