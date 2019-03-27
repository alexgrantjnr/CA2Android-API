using System;
using CA2Service.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


/*
 Developers:
 Bren Dempsey & Alex Grant
 4th Year Software Students
 EAD2 - CA2[Elapsed]
 Out: 28/02/2019
 Due: 31/03/2019
*/

using Swashbuckle.AspNetCore.Swagger; //Needed for Info object below using Swagger!!

namespace CA2Service
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //DB context string maps to the applicationsettings
            services.AddDbContext<PlayerContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("AzureConnection")));
            services.BuildServiceProvider().GetService<PlayerContext>().Database.Migrate();

            //*** SWAGGER Implementation *** //            

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Football Legends API Service", Version = "v1" });
            });

            //*** SWAGGER Implementation *** //
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //*** SWAGGER Implementation *** //

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Football Legends API V1");
            });

            //*** SWAGGER Implementation *** // 

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}