using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using contractorserver.Repositories;
using contractorserver.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySqlConnector;

namespace contractorserver
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
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
              {
                  options.Authority = $"https://{Configuration["Auth0:Domain"]}/";
                  options.Audience = Configuration["Auth0:Audience"];
              });
            services.AddCors(options =>
            {
                options.AddPolicy("CorsDevPolicy", builder =>
                {
                        builder
                            .WithOrigins(new string[]{
                            "http://localhost:8080",
                            "http://localhost:8081"
                            })
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
            });
            services.AddControllers();
            services.AddScoped<IDbConnection>(x => CreateDbConnection());

            services.AddTransient<ProfilesService>();
            services.AddTransient<ProfilesRepository>();

            services.AddTransient<ContractorsService>();
            services.AddTransient<ContractorsRepository>();

            services.AddTransient<JobsService>();
            services.AddTransient<JobsRepository>();

             services.AddTransient<BidsService>();
            services.AddTransient<BidsRepository>();
            
             services.AddTransient<ReviewsService>();
            services.AddTransient<ReviewsRepository>();

        }

        private IDbConnection CreateDbConnection()
        {
            var connectionString = Configuration.GetSection("DB").GetValue<string>("gearhost");
            return new MySqlConnection(connectionString);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("CorsDevPolicy");
            }
             Auth0ProviderExtension.ConfigureKeyMap(new List<string>() {"id"});

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
