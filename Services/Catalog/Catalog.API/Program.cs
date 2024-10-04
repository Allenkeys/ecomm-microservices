using Catalog.API.Configurations;
using System.Reflection;
using Catalog.Application.Mappers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
    c.SwaggerDoc("Catalog", new Microsoft.OpenApi.Models.OpenApiInfo 
    { 
        Title = "Catalog API", 
        Version = "v1",
        Description = "Catalog Microservice App"
    }));

builder.Services.ConfigureAppSettings(builder.Configuration);
builder.Services.RegisterServices();
builder.Services.AddAutoMapper(typeof(BrandsMappingProfile));
var assemblies = AppDomain.CurrentDomain.GetAssemblies();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/Catalog/swagger.json", "Catalog API"));
}

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
