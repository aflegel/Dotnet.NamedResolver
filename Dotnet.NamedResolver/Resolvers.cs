using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Dotnet.NamedResolver
{
    public delegate IService ServiceResolver(string key);
    public class Resolvers
    {
        public static Func<IServiceProvider, ServiceResolver> NamedResolver => serviceProvider => key => key switch
        {
            "A" => serviceProvider.GetService<ServiceA>(),
            "B" => serviceProvider.GetService<ServiceB>(),
            "C" => serviceProvider.GetService<ServiceC>(),
            _ => throw new KeyNotFoundException(),
        };

        public static Func<IServiceProvider, ServiceResolver> NamedResolver2 => serviceProvider => key =>
        {
            var serviceList = serviceProvider.GetServices<IService>();

            return serviceList.FirstOrDefault(w => w.Name == key);
        };
    }
}
