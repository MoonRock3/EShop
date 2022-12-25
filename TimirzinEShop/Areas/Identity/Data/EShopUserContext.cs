using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimirzinEShop.Areas.Identity.Data;

namespace TimirzinEShop.Areas.Identity.Data
{
    public class EShopUserContext : IdentityDbContext<EShopUser>
    {
        public EShopUserContext(DbContextOptions<EShopUserContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ЕГОР-ПК;Initial Catalog=Timirzin_AS-51_OLD;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
