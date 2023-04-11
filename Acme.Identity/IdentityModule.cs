using System.IO;
using System.Reflection;
using Acme.Identity.IdentityUser;
using Acme.Identity.Others;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;

namespace Acme.Identity
{
    [DependsOn(typeof(Volo.Abp.AspNetCore.Mvc.UI.AbpAspNetCoreMvcUiModule))]
    [DependsOn(typeof(Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.AbpAspNetCoreMvcUiBootstrapModule))]
    [DependsOn(typeof(Volo.Abp.AutoMapper.AbpAutoMapperModule))]
    [DependsOn(typeof(Volo.Abp.EntityFrameworkCore.AbpEntityFrameworkCoreModule))]
    [DependsOn(typeof(Volo.Abp.VirtualFileSystem.AbpVirtualFileSystemModule))]
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    public class IdentityModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            #region Preconfig setting tutorial

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                //Add plugin assembly
                mvcBuilder.PartManager.ApplicationParts.Add(new AssemblyPart(typeof(IdentityModule).Assembly));

                //Add views assembly
                var viewDllPath = Path.Combine(Path.GetDirectoryName(typeof(IdentityModule).Assembly.Location), "Acme.Identity.Views.dll");
                var viewAssembly = new CompiledRazorAssemblyPart(Assembly.LoadFrom(viewDllPath));
                mvcBuilder.PartManager.ApplicationParts.Add(viewAssembly);
            });

            #endregion
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            // Se configura el esquema de autenticacion por coockies, y se establece las rutas de login, logout.
            context.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/login";
                    options.LogoutPath = "/logout";
                    options.AccessDeniedPath = "/AccessDenied";
                });

            context.Services.AddHttpContextAccessor();

            ConfigureAutoMapper(context);
            ConfigureEfCore(context);
            ConfigureVirtualFiles(context);
            ConfigureAutoApiControllers();
            ConfigureBundles();

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new IdentityAppMenuContributor());
            });

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new IdentityAccountUserMenuContributor());
            });

            Configure<AbpToolbarOptions>(options =>
            {
                options.Contributors.Add(new AccountLoginToolbarContributor());
            });
        }

        private void ConfigureAutoMapper(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<IdentityModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                /* Uncomment `validate: true` if you want to enable the Configuration Validation feature.
                 * See AutoMapper's documentation to learn what it is:
                 * https://docs.automapper.org/en/stable/Configuration-validation.html
                 */
                options.AddMaps<IdentityModule>( /* validate: true */);
            });
        }

        private void ConfigureEfCore(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<IdentityDbContext>(options =>
            {
                /* You can remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots
                 * Documentation: https://docs.abp.io/en/abp/latest/Entity-Framework-Core#add-default-repositories
                 */
                options.AddRepository<User, EfCoreRepository<IdentityDbContext, User, int>>();
            });
        }

        private void ConfigureAutoApiControllers()
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(IdentityModule).Assembly);
            });
        }

        private void ConfigureVirtualFiles(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<IdentityModule>("Acme.Identity");
            });
        }

        private void ConfigureBundles()
        {
            Configure<AbpBundlingOptions>(options =>
            {
                options.ScriptBundles.Configure(StandardBundles.Scripts.Global,
                    bundle => { bundle.AddFiles("/js/site.js"); });
            });
        }
    }
}