using ClickerProject.Infrastructure.Implemetations;
using Microsoft.EntityFrameworkCore;

namespace ClickerProject.Initialization
{
    public static class DbContextInitializer
    {
        public static void InitializeDbContext(IServiceCollection services) 
        {
            services.AddDbContext<AppDbContext>(o => o.UseSqlite($"Data source={GetPathDatabaseFile()}"));
        }

        public static void InitializeDataBase(AppDbContext dbContext)
        {
            dbContext.Database.Migrate();
        }

        private static string GetPathDatabaseFile()
        {
            var pathToLocalApplication = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            var dbFilePath = Path.Combine(pathToLocalApplication, "ClickerProject", "ClickerProject.db");

            return dbFilePath;
        }
    }
}
