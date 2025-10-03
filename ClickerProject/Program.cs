using ClickerProject.Initialization;

var builder = WebApplication.CreateBuilder(args);

DbContextInitializer.InitializeDbContext(builder.Services);




var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var appDbContext = scope.ServiceProvider.
}

app.MapGet("/", () => "Hello World!");

app.Run();