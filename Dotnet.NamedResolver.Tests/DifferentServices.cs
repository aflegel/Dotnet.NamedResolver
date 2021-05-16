using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Dotnet.NamedResolver.Tests
{
    public class DifferentServices
    {
        [Theory]
        [InlineData("A", 1)]
        [InlineData("B", 2)]
        [InlineData("C", 3)]
        public void Test1(string key, int value)
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<ServiceA>();
            services.AddSingleton<ServiceB>();
            services.AddSingleton<ServiceC>();
            services.AddSingleton(Resolvers.NamedResolver);

            var provider = services.BuildServiceProvider();

            var resolver = provider.GetService<ServiceResolver>();

            var service = resolver(key);
            service.UniqueNumber.Should().Equals(value);
        }
    }
}
