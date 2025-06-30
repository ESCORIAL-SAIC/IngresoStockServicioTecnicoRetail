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
            // Cargar configuración desde appsettings.json y appsettings.{ENV}.json
            var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production";

            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                .Build();

            // Inicializar la app
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmInicio());
        }
    }
}
