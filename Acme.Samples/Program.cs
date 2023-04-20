using System;
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
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Debug)
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
            var builder = CreateHostBuilder(args);
            var app = builder.Build();
            if (IsMigrateDatabase(args))
            {
                await app.Services.GetRequiredService<SamplesDbMigrationService>().MigrateAsync();
                return 0;
            }
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
    
    internal static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(build =>
            {
                build.AddJsonFile("appsettings.secrets.json", optional: true);
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .UseAutofac()
            .UseSerilog();
}

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<SamplesModule>(options =>
        {
            void AddRefForNet7()
            {
                var path = options.Services.GetHostingEnvironment().ContentRootPath;
                var directoryInfo = new DirectoryInfo(path);
                var folder = string.Empty;
    #if DEBUG
                folder = Path.Combine(directoryInfo.Parent.FullName, "Washyn.Samples","bin","Debug","net7.0");
    #else
                    folder = Path.Combine(directoryInfo.Parent.FullName, "Washyn.Samples","bin","Release","net7.0");
    #endif
                options.PlugInSources.AddFolder(folder);
            }
            void AddNet6()
            {
                var path = options.Services.GetHostingEnvironment().ContentRootPath;
                var directoryInfo = new DirectoryInfo(path);
                var folder = string.Empty;
#if DEBUG
                folder = Path.Combine(directoryInfo.Parent.FullName, "Washyn.Samples","bin","Debug","net6.0");
#else
                folder = Path.Combine(directoryInfo.Parent.FullName, "Washyn.Samples","bin","Release","net6.0");
#endif
                options.PlugInSources.AddFolder(folder);
            }
            
#if NET_7
            AddRefForNet7();
#endif
            
#if NET6_0
            AddNet6();
#endif


        });
    }

    public void Configure(IApplicationBuilder app)
    {
        app.InitializeApplication();
    }
}