using AgendaContatos.Categorias.Models;
using AgendaContatos.Contatos.Models;
using AgendaContatos.Core.Infraestrutura;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows.Forms;

namespace AgendaContatos
{
    internal class Program
    {

        private static IServiceCollection Services;
        public static IServiceProvider ServiceProvider;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IConfiguration configuration = SetConfigurations();
            CreateServices(configuration);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmPrincipal());
        }

        static IConfiguration SetConfigurations()
        {
            return new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .AddUserSecrets<Program>()
                    .Build();
        }

        static void CreateServices(IConfiguration configuration)
        {
            Services = new ServiceCollection();
            Services.AddSingleton(configuration);
            Services.AddScoped<ICategoriasDatabase, CategoriasDatabase>();
            Services.AddScoped<IContatosDatabase, ContatosDatabase>();
            Services.AddScoped<IConnectionFactory, ConnectionFactory>();
            ServiceProvider = Services.BuildServiceProvider();
        }
    }
}
