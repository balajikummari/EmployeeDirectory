using Castle.Core;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EmployeeDirectory.Sqlite;
using EmployeeDirectory.Models;
using EmployeeDirectory.ViewModels;
using System;
using System.Collections.Generic;
using System.Reflection;
using GenericMVVM;

namespace EmployeeDirectory.Views
{
    public class Bootstrapper : BootstrapperBase {
        private WindsorContainer container;

        protected override IEnumerable<Assembly> SelectAssemblies() {
            return new[] {typeof (ShellViewModel).Assembly};
        }

        protected override void ConfigureForRuntime() {
            container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new AppSettingHandler());
            container.Register(
                Component.For<IRepository<Employee>>()
                    .ImplementedBy<EmployeeRepository>()
                     .LifestyleTransient()
                   // .DependsOn(Dependency.OnValue<string>("C:\\Users\\Bobby\\source\\repos\\EmployeeDirectory\\EmployeeDirectory.DataAccess\\EmployeeDB.xml"))
                   ,
                Component.For<IEventAggregator>()
                    .ImplementedBy<EventAggregator>()
                    .LifestyleSingleton(),
                Component.For<EmployeeDbContext>()
                    .ImplementedBy<EmployeeDbContext>()
                    .LifestyleSingleton()
              );
            RegisterViewModels();
            container.AddFacility<TypedFactoryFacility>();
        }

        protected override void ConfigureForDesignTime()
        {
            container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new AppSettingHandler());
            RegisterViewModels();
            container.AddFacility<TypedFactoryFacility>();
        }

        protected override object GetInstance(Type service, string key) {
            return string.IsNullOrWhiteSpace(key)
                ? container.Resolve(service)
                : container.Resolve(key, service);
        }
   
        private void RegisterViewModels() {
            container.Register(Classes.FromAssembly(typeof(MainViewModel).Assembly)
                .Where(x => x.Name.EndsWith("ViewModel"))
                .Configure(x => x.LifeStyle.Is(LifestyleType.Transient)));
        }
    }
}