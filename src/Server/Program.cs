using System;
using System.Threading.Tasks;
using MVWorkflows.Infrastructure.Contexts;
using MVWorkflows.Server.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MVWorkflows.Server
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var loadedPaths = loadedAssemblies.Select(a => a.Location).ToArray();

            var referencedPaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll").ToList();
            var toLoad = referencedPaths.Where(r => !loadedPaths.Contains(r, StringComparer.InvariantCultureIgnoreCase)).ToList();

            referencedPaths.ForEach(path =>
            {
                try
                    {
                    loadedAssemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path)))
                 ;
                }
                catch (Exception ex)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        if (ex is FileNotFoundException)
                        {
                            sb.AppendLine(((FileNotFoundException)ex).FusionLog);
                            sb.AppendLine();
                            if (ex.InnerException != null)
                            {
                                if (ex.InnerException is FileNotFoundException)
                                {
                                    sb.AppendLine(((FileNotFoundException)ex.InnerException).FusionLog);
                                    sb.AppendLine();
                                    if (ex.InnerException.InnerException != null)
                                    {
                                        if (ex.InnerException.InnerException is FileNotFoundException)
                                        {
                                            sb.AppendLine(((FileNotFoundException)ex.InnerException.InnerException).FusionLog);
                                            sb.AppendLine();
                                        }
                                    }
                                }
                            }
                        }

                        //Utilities.ExceptionUtilities.ExceptionUtilities.LogError(ConfigurationManager.AppSettings["LogFoldePath"],
                        //    new Exception(sb.ToString(), ex));
                    }
                    catch (Exception ex2)
                    { }
                }
            }
            );

            try
            {
                var host = CreateHostBuilder(args).Build();

                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;

                    try
                    {
                        var context = services.GetRequiredService<BlazorHeroContext>();

                        if (context.Database.IsSqlServer())
                        {
                            context.Database.Migrate();
                        }
                    }
                    catch (Exception ex)
                    {
                        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

                        logger.LogError(ex, "An error occurred while migrating or seeding the database.");

                        throw;
                    }
                }

                await host.RunAsync();
            }
            catch(Exception ex)
            {

            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    try { 
                    webBuilder.UseStaticWebAssets();
                        //webBuilder.MabBl
                    webBuilder.UseStartup<Startup>();
                    }
                    catch (Exception ex)
                    { }
                });
    }
}