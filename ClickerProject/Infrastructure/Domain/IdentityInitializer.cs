using ClickerProject.Infrastructure.Implemetations;
using Microsoft.AspNetCore.Identity;

namespace ClickerProject.Domain
{
    public static class IdentityInitializer
    {
        public static void Initialize(IServiceCollection services) 
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            services.Configure<IdentityOptions>(c => c.Password.RequireNonAlphanumeric = false);
        }
    }
}
