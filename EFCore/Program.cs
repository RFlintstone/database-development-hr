using EFCore.DataStore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register AppDbContext with a connection string
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Services
builder.Services.AddAuthorization();
builder.Services.AddControllers();

var app = builder.Build();

// Middleware
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    db.Database.Migrate();
    db.Seed();
}

// Test endpoint
app.MapGet("/", () => "Hello, World!");

app.Run();