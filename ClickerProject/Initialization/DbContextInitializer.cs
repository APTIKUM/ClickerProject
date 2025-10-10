using ClickerProject.Infrastructure.Implemetations;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace ClickerProject.Initialization
{
    public static class DbContextInitializer
    {
        public static void InitializeDbContext(IServiceCollection services)
        {
            Batteries.Init();
            services.AddDbContext<AppDbContext>(o => o.UseSqlite($"Data source={GetPathDatabaseFile()}"));
        }

        public static void InitializeDataBase(AppDbContext dbContext)
        {

            dbContext.Database.Migrate();
        }

        private static string GetPathDatabaseFile()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var appFolder = Path.Combine(appDataPath, "ClickerProject");

            Directory.CreateDirectory(appFolder);

            var dbPath = Path.Combine(appFolder, "ClickerProject.db");
            Console.WriteLine($"Database path: {dbPath}");
            return dbPath;
        }
    }
}
