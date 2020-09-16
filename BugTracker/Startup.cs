using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTracker.Data;
using BugTracker.Data.Helpers;
using BugTracker.Data.Repositories;
using BugTracker.Logic.Logic;
using BugTracker.Web.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace BugTracker.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //configure database
            services.AddDbContext<BugTrackerDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            //default logger
            services.AddLogging();

            //add http context for DI
            services.AddHttpContextAccessor();
            services.AddTransient<IRequestUser, RequestUser>();

            //configure app settings 
            var jwtSettingsSection = Configuration.GetSection("JWTSettings");
            services.Configure<JWTSettings>(jwtSettingsSection);
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.Configure<HashingOptions>(Configuration.GetSection("HashingOptions"));

            //configure jwt authentication
            var jwtSettings = jwtSettingsSection.Get<JWTSettings>();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = false;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
            });

            //add authorization policies...

            //add custom services
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomLogger, CustomLogger>();    
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IUserLogic, UserLogic>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureExceptionMiddleware();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //override mapping to keep .net core from interferring with angular routing
            app.MapWhen(
                context =>
                {
                    var path = context.Request.Path.Value.ToLower();
                    return path.Contains("/") &&
                           !path.Contains(".js") &&
                           !path.Contains("/api/") &&
                           !path.Contains("/assets") &&
                           !path.Contains(".ico");
                },
                branch =>
                {
                    branch.Use((context, next) =>
                    {
                        context.Request.Path = new PathString("/index.html");
                        return next();
                    });

                    branch.UseStaticFiles();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints
                    .MapControllers()
                    .RequireAuthorization();
            });
        }
    }
}
