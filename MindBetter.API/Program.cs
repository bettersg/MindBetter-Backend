using Microsoft.EntityFrameworkCore;
using MindBetter.Infrastructure.Data;
using MindBetter.Infrastructure.Data.Config;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000");
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(
    opt => opt.UseSqlite(
        "Data Source=MindBetterTest.db",
        b => b.MigrationsAssembly("MindBetter.Infrastructure")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
#if DEBUG
        context.Database.EnsureDeleted();
#endif
        context.Database.Migrate();
        await Seed.SeedAsync(context, app.Logger);
    }
    catch (Exception ex)
    {
        app.Logger.LogInformation($"Migration on startup failed {ex}");
    }
}

app.Logger.LogInformation("App created...");

app.Logger.LogInformation("Seeding Database...");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
