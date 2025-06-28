using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmartOPS.API.Data;
using SmartOPS.API.Repository.Implementation;
using SmartOPS.API.Repository.Interface;
using SmartOPS.API.Service.Implementation;
using SmartOPS.API.Service.Interface;
using System.Text;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
// Swagger
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 36)))
);

// Dependency Injection
builder.Services.AddScoped<IJobService, JobServiceImpl>();
builder.Services.AddScoped<IJobRepository, JobRepositoryImpl>();
builder.Services.AddScoped<IUserService, UserServiceImpl>();
builder.Services.AddScoped<IUserRepository, UserRepositoryImpl>();
builder.Services.AddScoped<ICompanyService, CompanyServiceImpl>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepositoryImpl>();
builder.Services.AddScoped<IUserTokenService, UserTokenServiceImpl>();
builder.Services.AddScoped<IUserTokenRepository, UserTokenRepositoryImpl>();
builder.Services.AddScoped<IPasswordResetRepository, PasswordResetRepositoryImpl>();
builder.Services.AddScoped<IPasswordResetService, PasswordResetServiceImpl>();

// Authentication Token
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var config = builder.Configuration;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = config["Jwt:Issuer"],
        ValidAudience = config["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))
    };
});
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseAuthentication();
    app.UseAuthorization();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
