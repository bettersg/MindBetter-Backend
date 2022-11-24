using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MindBetter.Infrastructure.Data;
using MindBetter.Infrastructure.Data.Config;
using MindBetter.Infrastructure.Data.Services;
using System.Text;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Logging.AddConsole();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
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

builder.Services.AddScoped<INonProfitRepository, NonProfitRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Authentication providers
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
        };
    });

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
