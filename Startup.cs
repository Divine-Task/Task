using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Config;
using Task.Pages;

namespace Task
{
    internal class Startup
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();

            services
                .AddSingleton(ConfigReader.ReadConfig());
                //.AddScoped<IDriverFixture, DriverFixture>()
                //.AddScoped<IDriverWait, DriverWait>()
                //.AddScoped<HomePage, HomePage>();
                //.AddScoped<ProductPage, ProductPage>();

            return services;
        }
    }
}
