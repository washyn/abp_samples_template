using System;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Acme.Identity.IdentityUser
{
    /// <summary>
    /// Base class for the Entity Framework database context used for identity.
    /// </summary>
    [ConnectionStringName(AbpIdentityDbProperties.ConnectionStringName)]
    public class IdentityDbContext : AbpDbContext<IdentityDbContext>, IIdentityDbContext
    {
        public DbSet<User> Users { get; }

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.ConfigureIdentity();
        }
    }

    [ConnectionStringName(AbpIdentityDbProperties.ConnectionStringName)]
    public interface IIdentityDbContext : IEfCoreDbContext
    {
        DbSet<User> Users { get; }
    }

    public static class AbpIdentityDbProperties
    {
        public static string DbTablePrefix { get; set; } = "App.";
        public static string DbSchema { get; set; } = null;
        public const string ConnectionStringName = "AbpIdentity";
    }

    public class IdentityModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public IdentityModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix,
            [CanBeNull] string schema)
            : base(
                tablePrefix, 
                schema)
        {

        }
    }
    
    public static class IdentityDbContextModelBuilderExtensions
    {
        public static void ConfigureIdentity([NotNull] this ModelBuilder builder,
            [CanBeNull] Action<IdentityModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));
        
            var options = new IdentityModelBuilderConfigurationOptions(AbpIdentityDbProperties.DbTablePrefix,
                AbpIdentityDbProperties.DbSchema);
        
            optionsAction?.Invoke(options);
        
            builder.Entity<User>(b =>
            {
                b.ToTable(options.TablePrefix + "Users", options.Schema);
        
                b.ConfigureByConvention();
                // b.ConfigureAbpUser();
                //
                // b.Property(u => u.NormalizedUserName)
                //     .IsRequired()
                //     .HasMaxLength(IdentityUserConsts.MaxNormalizedUserNameLength)
                //     .HasColumnName(nameof(IdentityUser.NormalizedUserName));
                // b.Property(u => u.NormalizedEmail)
                //     .IsRequired()
                //     .HasMaxLength(IdentityUserConsts.MaxNormalizedEmailLength)
                //     .HasColumnName(nameof(IdentityUser.NormalizedEmail));
                // b.Property(u => u.PasswordHash)
                //     .HasMaxLength(IdentityUserConsts.MaxPasswordHashLength)
                //     .HasColumnName(nameof(IdentityUser.PasswordHash));
                // b.Property(u => u.SecurityStamp)
                //     .IsRequired()
                //     .HasMaxLength(IdentityUserConsts.MaxSecurityStampLength)
                //     .HasColumnName(nameof(IdentityUser.SecurityStamp));
                // b.Property(u => u.TwoFactorEnabled)
                //     .HasDefaultValue(false)
                //     .HasColumnName(nameof(IdentityUser.TwoFactorEnabled));
                // b.Property(u => u.LockoutEnabled)
                //     .HasDefaultValue(false)
                //     .HasColumnName(nameof(IdentityUser.LockoutEnabled));
                //
                // b.Property(u => u.IsExternal)
                //     .IsRequired()
                //     .HasDefaultValue(false)
                //     .HasColumnName(nameof(IdentityUser.IsExternal));
                //
                // b.Property(u => u.AccessFailedCount)
                //     .If(!builder.IsUsingOracle(), p => p.HasDefaultValue(0))
                //     .HasColumnName(nameof(IdentityUser.AccessFailedCount));
                //
                // b.HasMany(u => u.Claims).WithOne().HasForeignKey(uc => uc.UserId).IsRequired();
                // b.HasMany(u => u.Logins).WithOne().HasForeignKey(ul => ul.UserId).IsRequired();
                // b.HasMany(u => u.Roles).WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
                // b.HasMany(u => u.Tokens).WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
                // b.HasMany(u => u.OrganizationUnits).WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
                //
                // b.HasIndex(u => u.NormalizedUserName);
                // b.HasIndex(u => u.NormalizedEmail);
                // b.HasIndex(u => u.UserName);
                // b.HasIndex(u => u.Email);
                //
                // b.ApplyObjectExtensionMappings();
            });
            
            builder.TryConfigureObjectExtensions<IdentityDbContext>();
        }
    }
}