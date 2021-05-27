using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TaskTrackingSystem.BLL.Services;
using TaskTrackingSystem.BLL.Services.Interfaces;

namespace TaskTrackingSystem.Web.AppStart
{
    public static class ConfigureJwtAuthenticationExtension
    {
        public static void AddJwtAuthentication(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtOptions:JwtKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
            
            if (!int.TryParse(configuration["JwtOptions:JwtExpireDays"], out var expireDays))
                throw new ArgumentException("JwtExpireDays can't convert to int value!");
            
            var jwtHandler = new JwtService(configuration["JwtOptions:JwtKey"], expireDays, configuration["JwtOptions:JwtIssuer"]);
            services.AddSingleton<IJwtService>(jwtHandler);
        }
    }
}