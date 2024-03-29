using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Plant_Watering_App_Backend.Dal;
using Plant_Watering_App_Backend.Dal.FakeRepositories;
using Plant_Watering_App_Backend.Dal.Repositories;
using Plant_Watering_App_Backend.Interfaces;
using Plant_Watering_App_Backend.Models;

namespace Plant_Watering_App_Backend
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
            services.AddControllers();

            // Repositories

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            //if (env == "Development")
            //{
                services.AddScoped<IPlantRepository, FakePlantRepository>();
                //services.AddScoped<IPlantRepository, PlantRepository>();

            //}
            //else 
            //{
            //    services.AddScoped<IPlantRepository, PlantRepository>();
            //}

            //// PostgreSQL
            //services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationDBContext>(options =>
            //{
            //    //var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            //    string connStr;
            //    // Depending on if in development or production, use either Heroku-provided
            //    // connection string, or development connection string from env var.
            //    if (env == "Development")
            //    {
            //        // Use connection string from file.
            //        connStr = Configuration.GetConnectionString("DefaultConnection");
            //        // will actually be using a fake repo so this line above isn't needed
            //    }
            //    else
            //    {
            //        // Use connection string provided at runtime by Heroku.
            //        var connUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            //        // Parse connection URL to connection string for Npgsql
            //        connUrl = connUrl.Replace("postgres://", string.Empty);
            //        var pgUserPass = connUrl.Split("@")[0];
            //        var pgHostPortDb = connUrl.Split("@")[1];
            //        var pgHostPort = pgHostPortDb.Split("/")[0];
            //        var pgDb = pgHostPortDb.Split("/")[1];
            //        var pgUser = pgUserPass.Split(":")[0];
            //        var pgPass = pgUserPass.Split(":")[1];
            //        var pgHost = pgHostPort.Split(":")[0];
            //        var pgPort = pgHostPort.Split(":")[1];
            //        connStr = $"Server={pgHost};Port={pgPort};User Id={pgUser};Password={pgPass};Database={pgDb};sslmode=Prefer;Trust Server Certificate=true";
            //    }
            //    // Whether the connection string came from the local development configuration file
            //    // or from the environment variable from Heroku, use it to set up your DbContext.
            //    options.UseNpgsql(connStr);
            //});


            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Plants API",
                    Version = "v1",
                    Description = "An API to manage plants watering",
                    TermsOfService = new Uri("https://ExampleWebsite.com/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Josh A",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/joshADE")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MY Company Licence",
                        Url = new Uri("https://ExampleWebsite.com/"),
                    }

                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // CORS
            app.UseCors(options => options
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            // Swagger
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Plants API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
