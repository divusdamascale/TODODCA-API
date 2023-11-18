using Microsoft.EntityFrameworkCore;
using ToDoList.API.Data;
using Microsoft.Extensions;
using ToDoList.API.Utils;
using ToDoList.API.Services;
using ToDoList.API.Repositories;
using System.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var jwtOptions = builder.Configuration.GetSection("SettingsOptions").Get<SettingsOptions>();
builder.Services.AddSingleton(jwtOptions);

builder.Services.AddControllers();
UtilsConfig.ConfigureServices(builder.Services);
RepoConfig.ConfigureServices(builder.Services);
ServicesConfig.ConfigureServices(builder.Services,jwtOptions);

builder.Services.AddSwaggerGen();




builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["SettingsOptions:Jwt:Audience"],
                    ValidIssuer = builder.Configuration["SettingsOptions:Jwt:Issuer"],
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SettingsOptions:Jwt:Secret"]))
                };
            });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Define the JWT Bearer token scheme with "Bearer" as the default name
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT" // Adaugă "Bearer" ca format implicit
    });

    // Add the JWT Bearer token requirement for endpoints
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});



// Add Swagger services
builder.Services.AddEndpointsApiExplorer();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors(options =>
{
    options.AllowAnyOrigin(); 
    options.AllowAnyMethod(); 
    options.AllowAnyHeader(); 
});

app.MapControllers();

app.Run();
