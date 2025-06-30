using Microsoft.Extensions.Configuration;
using System;
using System.Windows.Forms;

namespace IngresoStockServicioTecnicoRetail
{
    internal static class Program
    {
        public static IConfiguration Configuration { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production";

            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                .Build();

            ApplicationConfiguration.Initialize();
            Application.Run(new FrmInicio());
        }
    }
}
