using Microsoft.EntityFrameworkCore;
using JobHelper.Api.Data;

var DevelopmentCorsPolicy = "_developmentCorsPolicy";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add CORS policy.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: DevelopmentCorsPolicy,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

// Register Database connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors(DevelopmentCorsPolicy);
app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => new { message = "ASP NET API is Running..." });
app.MapGet("/status", () => new { message = "ASP NET API is Running...", status = true });
app.MapGet("/api/health/database", async (AppDbContext db) =>
{
    var connected = await db.Database.CanConnectAsync();

    if (!connected)
    {
        return Results.Problem(
            "Could not connect to the database.",
            statusCode: 503
        );
    }

    return Results.Ok(new
    {
        message = "Successfully connected to PostgreSQL!"
    });
});

app.Run();
