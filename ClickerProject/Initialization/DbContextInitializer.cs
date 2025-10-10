using ClickerProject.Infrastructure.Implemetations;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace ClickerProject.Initialization
{
    public static class DbContextInitializer
    {
        //public static void InitializeDbContext(IServiceCollection services) 
        //{
        //    Batteries.Init();
        //    services.AddDbContext<AppDbContext>(o => o.UseSqlite($"Data source={GetPathDatabaseFile()}"));
        //}
        public static void InitializeDbContext(IServiceCollection services)
        {
            var dbPath = "ClickerProject.db";
            Console.WriteLine($"Database location: {Path.GetFullPath(dbPath)}");
            Batteries.Init();
            services.AddDbContext<AppDbContext>(o => o.UseSqlite($"Data source={dbPath}"));
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
