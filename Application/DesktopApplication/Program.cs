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
                    services.AddTransient<IUserService, UserService>();
                    services.AddTransient<IEventService, EventService>();
                    services.AddTransient<IEventDAL, EventDAL>();
                    services.AddTransient<ISoftService, SoftService>();
                    services.AddTransient<ISoftDAL, SoftDAL>();
                    services.AddTransient<IAlcoholService, AlcoholService>();
                    services.AddTransient<IAlcoholDAL, AlcoholDAL>();
                    services.AddTransient<IReportService, ReportService>();
                    services.AddTransient<IReportDAL, ReportDAL>();
                    services.AddTransient<IReservationService, ReservationService>();
                    services.AddTransient<IReservationDAL, ReservationDAL>();
                    services.AddTransient<ICommentsService, CommentsService>();
                    services.AddTransient<ICommentsDAL, CommentsDAL>();
                    services.AddTransient<IBeverageDAL, BeverageDAL>();
                    services.AddTransient<Login>();
                });
        }
    }
}