using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using InterfacesDAL;
using InterfacesLL;
using LogicLayer;
using DataAccessLayer;

namespace DesktopApplication
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<Login>());
        }

        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddTransient<IUserDAL, UserDAL>();
                    services.AddTransient<IUserLL, UserLL>();
                    services.AddTransient<Login>();
                });
        }
    }
}