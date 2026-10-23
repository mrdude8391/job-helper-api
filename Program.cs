var DevelopmentCorsPolicy = "_developmentCorsPolicy";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add CORS policy.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: DevelopmentCorsPolicy,
                      policy  =>
                      {
                          policy.WithOrigins("http://localhost:5173")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

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

app.MapGet("/", () => "Hello world!");

app.Run();
