using Autofac;
using SiloVisionX.Application.Applications;
using SiloVisionX.Domain.Interfaces;
using SiloVisionX.Domain.Repositories;
using SiloVisionX.Infra.Repositories;

namespace SiloVisionX.API.DI
{
    public class DependencyInjectionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            builder.RegisterType<AuthApplication>().As<IAuthApplication>().InstancePerLifetimeScope();
            builder.RegisterType<DashboardApplication>().As<IDashboardApplication>().InstancePerLifetimeScope();
            builder.RegisterType<GeralRepository>().As<IGeralRepository>().InstancePerLifetimeScope();
            builder.RegisterType<HumRepository>().As<IHumRepository>().InstancePerLifetimeScope();
            builder.RegisterType<LoggerRepository>().As<ILoggerRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PesoRepository>().As<IPesoRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ReportApplication>().As<IReportApplication>().InstancePerLifetimeScope();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RolesApplication>().As<IRolesApplication>().InstancePerLifetimeScope();
            builder.RegisterType<TempRepository>().As<ITempRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TokenRepository>().As<ITokenRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserApplication>().As<IUserApplication>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();



        }
    }
}
