using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using RealEstate.Application;
using RealEstate.Persistence;

namespace RealEstate.WebApi
{
    public class RealServiceProviderFactory : AutofacServiceProviderFactory
    {
        public RealServiceProviderFactory() : base(Configure)
        {

        }

        private static void Configure(ContainerBuilder builder)
        {
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<PersistenceModule>();
        }
    }
}
