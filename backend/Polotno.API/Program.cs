using Microsoft.EntityFrameworkCore;
using Polotno.API.Models;
using Polotno.API.Controllers;
using Polotno.API.Mappings;
using Polotno.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);

builder.Services.AddDbContext<PolotnoContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        MySqlServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

builder.Services.AddControllers();
builder.Services.AddScoped<IGalleryRepository, MySqlGalleryRepository>();
builder.Services.AddScoped<IUserRepository, MySqlUserRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
