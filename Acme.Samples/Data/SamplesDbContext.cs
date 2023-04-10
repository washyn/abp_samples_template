//using Acme.Identity.IdentityUser;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.Samples.Data;

[ConnectionStringName("Default")]
public class SamplesDbContext : AbpDbContext<SamplesDbContext>
{
    public SamplesDbContext(DbContextOptions<SamplesDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        /* Include modules to your migration db context */
        /* Configure your own entities here */
        
        //builder.ConfigureIdentity();
    }
}
