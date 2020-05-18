using System;
using System.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Rasky.API.IdentityDb.Helpers;
using Rasky.API.IdentityDb.Helpers.Models;

namespace Rasky.API.IdentityDb {

    public  class IdentityConfig {
        // Adds what's needed for DI
         private const string SecretKey = "iNivDmHLpUA223sqsfhqGbMRdRj1PVkH"; // todo: get this from somewhere secure
         private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        public  void ConfigureIdentity (IServiceCollection services, IConfiguration  configuration) {
            services.AddDbContext<AppUserDbContext> ();
            services.AddIdentity<AppUser, IdentityRole> ()
                .AddEntityFrameworkStores<AppUserDbContext> ()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions> (options => {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;
                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes (5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                // User settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });
            services.AddTransient<IRideRepository,RideRepository>();
            services.AddTransient<IUserRepository,UserRepository>();
            services.AddTransient<IProfileRepository,ProfileRepository>();
            services.AddTransient<IAddressRepository,AddressRepository>();
            services.AddScoped<IRepositoryWrapper,RepositoryWrapper>();
            var jwtAppSettingOptions = configuration.GetSection (nameof (JwtIssuerOptions));

            // Configure JwtIssuerOptions
            services.Configure<JwtIssuerOptions> (options => {
                options.Issuer = jwtAppSettingOptions[nameof (JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof (JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials (_signingKey, SecurityAlgorithms.HmacSha256);
            });
            var tokenValidationParameters = new TokenValidationParameters {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof (JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof (JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            services.AddAuthentication (options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer (configureOptions => {
                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof (JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;
            });

            // api user claim policy
            services.AddAuthorization (options => {
                options.AddPolicy ("ApiUser", policy => policy.RequireClaim (Constants.Strings.JwtClaimIdentifiers.Rol, Constants.Strings.JwtClaims.ApiAccess));
            });
            services.AddSingleton<IJwtFactory, JwtFactory>();
        }

    }
}