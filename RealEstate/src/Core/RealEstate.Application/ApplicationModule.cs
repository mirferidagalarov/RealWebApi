using Autofac;
using Microsoft.Extensions.Configuration;
using RealEstate.Application.Contracts;
using RealEstate.Application.Implementations;
using RealEstate.Application.Modules;
using RealEstate.Domain.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterModule<CryptoModule>();
            builder.RegisterModule<EmailModule>();
            builder.RegisterModule<OtpModule>();
            builder.RegisterModule<DateTimeModule>();
        }
    }
}
