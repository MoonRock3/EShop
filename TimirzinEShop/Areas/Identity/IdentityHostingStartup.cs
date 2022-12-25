using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimirzinEShop.Areas.Identity.Data;

[assembly: HostingStartup(typeof(TimirzinEShop.Areas.Identity.IdentityHostingStartup))]
namespace TimirzinEShop.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<EShopUserContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("EShopUserIdentityConnection")));

                services.AddDefaultIdentity<EShopUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<EShopUserContext>();
                services.Configure<IdentityOptions>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 0;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                });
            });
        }
    }
}