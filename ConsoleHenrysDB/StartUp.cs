using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Henrys_DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using HenrysDbLayer;

namespace ConsoleHenrysDB
{
    public static class StartUp
    {
        private static IConfiguration Configuration { get; set; }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            Configuration = builder
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        internal static IHostBuilder CreateHostBuilder(string[] args)
        {
            BuildConfig(new ConfigurationBuilder());

            return Host.CreateDefaultBuilder(args)
                        .ConfigureServices(service => 
                        {
                            service.AddDbContext<HenrysDBContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("default")));
                            service.AddTransient<DBLogic>(dbl => 
                            {
                                var dbc = service.BuildServiceProvider().GetRequiredService<HenrysDBContext>();
                                return new DBLogic(dbc);
                            });
                        });
        }
    }
}
