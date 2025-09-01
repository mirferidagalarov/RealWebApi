using Autofac;
using RealEstate.Application.Contracts;
using RealEstate.Application.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Modules
{
     class DateTimeModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LocalDateTimeService>().As<IDateTimeService>().SingleInstance();

        }
    }
}
