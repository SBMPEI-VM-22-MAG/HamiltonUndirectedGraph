using HamiltonUndirectedGraph.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HamiltonUndirectedGraph
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // DI
            var services = new ServiceCollection()
                .AddTransient<IMessageService, MessageService>()
                ;

            using var serviceProvider = services.BuildServiceProvider();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(
                new Form1(serviceProvider.GetRequiredService<IMessageService>())
                );
        }
    }
}