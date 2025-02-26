using Microsoft.EntityFrameworkCore;
using Polotno.API.Models;
using Polotno.API.Controllers;
using Polotno.API.Mappings;
using Polotno.API.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

builder.Services.AddAuthentication(x => {
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => 
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.ASCII.GetBytes(builder.Configuration["JwtSettings:Key"]!)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") // Allow your React app's origin
                   .AllowAnyMethod() // Allow HTTP methods like GET, POST, PUT, DELETE
                   .AllowAnyHeader(); // Allow any headers
        });
});

var app = builder.Build();

app.UseCors("AllowReactApp"); // <--- ADD THIS LINE

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();