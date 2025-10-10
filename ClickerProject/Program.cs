using ClickerProject.Infrastructure.Implemetations;
using ClickerProject.Initialization;
using SQLitePCL;

var builder = WebApplication.CreateBuilder(args);



DbContextInitializer.InitializeDbContext(builder.Services);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    DbContextInitializer.InitializeDataBase(appDbContext);
}

app.MapGet("/", () => "Hello World!");

app.Run();