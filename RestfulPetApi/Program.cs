using Microsoft.EntityFrameworkCore;
using System;
using RestfulPetApi.Data;
using RestfulPetApi.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;
using RestfulPetApi.MapperProfile;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using RestfulPetApi.Validators;
using RestfulPetApi.Repositories;
using RestfulPetApi.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserClassValidator>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var jwtSettings = builder.Configuration.GetSection("JwtSettings");

builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddTransient<PetClassValidator>();
builder.Services.AddTransient<UserClassValidator>();
builder.Services.AddTransient<FoodClassValidator>();
builder.Services.AddTransient<HealthStatusClassValidator>();
builder.Services.AddTransient<ActivityClassValidator>();
builder.Services.AddTransient<SocialInteractionsClassValidator>();
builder.Services.AddTransient<TrainingClassValidator>();


builder.Services.AddScoped<PetClassRepo>();
builder.Services.AddScoped<FoodClassRepo>();
builder.Services.AddScoped<ActivityClassRepo>();
builder.Services.AddScoped<UserClassRepo>();
builder.Services.AddScoped<HealthStatusClassRepo>();


builder.Services.AddScoped<ActivityService>();
builder.Services.AddScoped<FoodService>();
builder.Services.AddScoped<HealthStatusService>();
builder.Services.AddScoped<PetService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "PetMaintenanceAPI", Version = "v1",
        Description = "Bu API, evcil hayvan bak�m�yla ilgili i�lemleri ger�ekle�tirmek i�in kullan�l�r."


    });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = JwtBearerDefaults.AuthenticationScheme
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            new string[]{}
        }
    });
});
// add JWT
builder.Services
    .AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

    })
    .AddJwtBearer(options =>
    {

        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings["SecretKey"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

//builder.Services.AddSwaggerGen(options =>
//{
//    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
//    {
//        Description = "Please provide:  Bearer [space] your token here ",
//        Name = "Authorization",
//        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
//        Scheme = "Bearer"
//    });
//    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
//    {
//        {
//            new Microsoft.OpenApi.Models.OpenApiSecurityScheme{
//                Reference=new Microsoft.OpenApi.Models.OpenApiReference{
//                    Type= Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
//                    Id="Bearer"
//                },
//                Scheme="oauth2",
//                Name="Bearer",
//                In=Microsoft.OpenApi.Models.ParameterLocation.Header
//            },
//            new List<String>()
//        }
//    });
//});
//var key = "kygmtest12345678kygmtest12345678kygmtest12345678";

//builder.Services.AddAuthentication(x =>
//{
//    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(x =>
//{
//    x.RequireHttpsMetadata = false;
//    x.SaveToken = true;
//    x.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
//        ValidateIssuer = false,
//        ValidateAudience = false
//    };
//});
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PetApiDb")));
builder.Services.AddScoped<JwtAuthenticationManager>(t => new JwtAuthenticationManager(jwtSettings["SecretKey"], t.GetRequiredService<AppDbContext>()));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
builder.Services.AddAuthorization();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();
