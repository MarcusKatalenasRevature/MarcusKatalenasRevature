using BusinessLayer;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using StoreAppApiDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAppApiMarksWay
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
            services.AddScoped<IOrderProductRepo, OrderProductRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StoreAppApiMarksWay", Version = "v1" });
            });

            
            services.AddDbContext<Project_1StoreAppDBContext>(options =>
            {
                //if db options is already configured, done do anything..
                // otherwise use the Connection string I have in secrets.json
                if (!options.IsConfigured)
                {
                    options.UseSqlServer(Configuration.GetConnectionString("MYDB"));
                }
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StoreAppApiMarksWay v1"));
            }

            app.UseStatusCodePages();

            app.UseHttpsRedirection();

            

            app.UseRewriter(new RewriteOptions()
                .AddRedirect("^$", "index.html"));

            // use the .js static files
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
