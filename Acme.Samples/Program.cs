using System;
using System.Runtime.InteropServices;
using Acme.Samples.Data;
using Serilog;
using Serilog.Events;
using Volo.Abp.Modularity.PlugIns;


namespace Acme.Samples;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        var loggerConfiguration = new LoggerConfiguration()
#if DEBUG
            .MinimumLevel.Debug()
#else
            .MinimumLevel.Information()
#endif
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.Async(c => c.File("Logs/logs.txt"))
            .WriteTo.Async(c => c.Console());

        if (IsMigrateDatabase(args))
        {
            loggerConfiguration.MinimumLevel.Override("Volo.Abp", LogEventLevel.Warning);
            loggerConfiguration.MinimumLevel.Override("Microsoft", LogEventLevel.Warning);
        }

        Log.Logger = loggerConfiguration.CreateLogger();

        try
        {
            // var builder = CreateHostBuilder(args);
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.AddAppSettingsSecretsJson()
                .UseAutofac()
                .UseSerilog();
            // var app = builder.Build();
            if (IsMigrateDatabase(args))
            {
                await builder.Services.GetRequiredService<SamplesDbMigrationService>().MigrateAsync();
                return 0;
            }

            await builder.AddApplicationAsync<TemplateModules>(options =>
            {
                #region Plugin

                var path = options.Services.GetHostingEnvironment().ContentRootPath;
                var directoryInfo = new DirectoryInfo(path);
                var folder = string.Empty;
#if DEBUG
                folder = Path.Combine(directoryInfo.Parent.FullName, "Acme.Identity","bin","Debug","net7.0");
#else
                folder = Path.Combine(directoryInfo.Parent.FullName, "Acme.Identity","bin","Release","net7.0");
#endif
                // options.PlugInSources.AddFolder(folder);
                
                #endregion

                var secondPlugin = string.Empty;
#if DEBUG
                secondPlugin = Path.Combine(directoryInfo.Parent.FullName, "Washyn.IdentityPlugin","bin","Debug","net7.0");
#else
                secondPlugin = Path.Combine(directoryInfo.Parent.FullName, "Washyn.IdentityPlugin","bin","Release","net7.0");
#endif
                options.PlugInSources.AddFolder(secondPlugin);
                Log.Information("secondPlugin");
                Log.Information("secondPlugin");
                Log.Information(secondPlugin);
                
            });
            var app = builder.Build();
            await app.InitializeApplicationAsync();
            
            Log.Information("Starting Acme.Samples.");
            
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            if (ex.GetType().Name.Equals("StopTheHostException", StringComparison.Ordinal))
            {
                throw;
            }

            Log.Fatal(ex, "Acme.Samples terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    private static bool IsMigrateDatabase(string[] args)
    {
        return args.Any(x => x.Contains("--migrate-database", StringComparison.OrdinalIgnoreCase));
    }
}