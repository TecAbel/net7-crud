using Microsoft.OpenApi.Models;
using WebAPICRUD.Roles;
using WebAPICRUD.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SAPS NET API",
        Version = "v1",
        Description = "API for SAPS, app",
    });
});

var identitySection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(identitySection);
// scopped services

builder.Services.AddScoped<IRolesService, RolesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
