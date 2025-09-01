using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RealEstate.Persistence.Context;

namespace RealEstate.Persistence
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(this.GetType().Assembly)
                .Where(x => x.IsClass && !x.IsAbstract)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();//Scoped


            builder.Register(c =>
            {
                var config = c.Resolve<IConfiguration>();

                var cfg = new DbContextOptionsBuilder()
                             .UseSqlServer(config.GetConnectionString("cString"), sqlServerOptions =>
                              {
                                  sqlServerOptions.CommandTimeout(15);
                                  sqlServerOptions.MigrationsHistoryTable("MigrationsHistory");
                              });

                return new DataContext(cfg.Options);
            }).As<DbContext>()
              .InstancePerLifetimeScope();//Scoped
        }
    }
}
