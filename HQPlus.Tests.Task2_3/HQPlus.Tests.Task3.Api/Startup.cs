using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HQPlus.Tests.Task3.RatesFilter;
using System.IO;
using Microsoft.Extensions.Hosting;
using AutoWrapper;

namespace HQPlus.Tests.Task3.Api
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
            string folder = Directory.GetCurrentDirectory();
            string fileName = "task 3 - hotelrates.json";

            var filePath = Path.Combine(folder, fileName);

            services.AddTransient<IRatesFilterOperation>(provider => new RatesFilterOperation(filePath));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseApiResponseAndExceptionWrapper();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
