using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Rasky.API.ViewModels;
using Rasky.API.ViewModels.Helpers;
using Rasky.API.ViewModels.Mapping;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Localization;
using My.Extensions.Localization.Json;
using Rasky.API.Configs;
using Rasky.API.IdentityDb;
using Rasky.API.Services;
using Twilio;

namespace Rasky.API {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddTransient<IEmailSender, EmailSender> ();
            services.AddOptions ();
            SmsSettings smsSettings = new SmsSettings ();
            Configuration.GetSection ("SmsSettings").Bind (smsSettings);
            EmailSettings emailSettings = new EmailSettings ();
            Configuration.GetSection ("EmailSettings").Bind (emailSettings);
            services.Configure<EmailSettings> (Configuration.GetSection ("EmailSettings"));
            TwilioClient.Init (smsSettings.SID, smsSettings.ApiKey);
            services.Configure<SmsSettings> (Configuration.GetSection ("SmsSettings"));
            services.AddTransient<ISmsSender, SmsSender> ();
            services.AddTransient<IProfileService,ProfileService>();
            services.AddTransient<IAuthService,AuthService>();
            services.AddTransient<IRideService,RideService>();
            services.AddJsonLocalization (o => {
                o.ResourcesPath = "Resources";
            });
            services.AddCors (options => {
                options.AddPolicy (MyAllowSpecificOrigins,
                    builder => {
                        builder.AllowAnyHeader ().AllowAnyMethod ().AllowAnyOrigin ().AllowCredentials ();
                    });
            });
            services.Configure<EmailSettings> (Configuration);
            services.AddMvc ().AddFluentValidation (fv => fv.RegisterValidatorsFromAssemblyContaining<Startup> ());
            (new IdentityConfig ()).ConfigureIdentity (services, Configuration);
            services.AddAuthorization ();
            services.AddSingleton (provider => new MapperConfiguration (cfg => {
                cfg.AddProfile (new ViewModelToEntityMappingProfile  (provider.GetService<IStringLocalizer<PublicProfileViewModel>> ()
                ,provider.GetService<IStringLocalizer<Message>>()));
            }).CreateMapper ());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            app.UseCors (MyAllowSpecificOrigins);
            app.UseStaticFiles ();
            IList<CultureInfo> supportedCultures = new List<CultureInfo> {
                new CultureInfo ("fr-FR"),
                new CultureInfo ("en-GB")
            };
            app.UseRequestLocalization (new RequestLocalizationOptions {
                DefaultRequestCulture = new RequestCulture ("fr-FR"),
                    SupportedCultures = supportedCultures,
                    SupportedUICultures = supportedCultures
            });

            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ();
            }
            app.UseAuthentication ();
            app.UseMvc ();

        }
    }
}