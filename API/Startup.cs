using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config; //private readonly variable
        public Startup(IConfiguration config) //being injected into class when configured 
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) //Container
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(_config.GetConnectionString("DefaultConnection")); //Connect to dB based on this specific connection string
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) //Check if in development mode
            {
                app.UseDeveloperExceptionPage(); //if problem, use exception page
            }

            app.UseHttpsRedirection(); //if we use a http page, get redirected

            app.UseRouting(); //Routing, 

            app.UseAuthorization(); //Authorisation - needs configured

            app.UseEndpoints(endpoints => //Middlewear end points
            {
                endpoints.MapControllers(); //Map Controllers
            });
        }
    }
}
