using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Views
{
    class AppSettingHandler : ISubDependencyResolver
    {
        public bool CanResolve(
           CreationContext context,
           ISubDependencyResolver contextHandlerResolver,
           ComponentModel model,
           DependencyModel dependency)
        {
            return ConfigurationManager.AppSettings.AllKeys
                .Contains(dependency.DependencyKey)
                   && TypeDescriptor
                       .GetConverter(dependency.TargetType)
                       .CanConvertFrom(typeof(string));
        }

        public object Resolve(
            CreationContext context,
            ISubDependencyResolver contextHandlerResolver,
            ComponentModel model,
            DependencyModel dependency)
        {
            return TypeDescriptor
                .GetConverter(dependency.TargetType)
                .ConvertFrom(
                    ConfigurationManager.AppSettings[dependency.DependencyKey]);
        }
    }
}
