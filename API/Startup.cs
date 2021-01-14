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
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using API.Extensions;

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
            services.AddApplicationServices(_config); //Extension Method
            services.AddControllers();
            services.AddCors(); //CORS - Cross-origin resource sharing 
            services.AddIdentityServices(_config); //Extension Method
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

            //CORS Policy to local host
            // x = policy
            app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200")); //Appropiate placing between Routing and Authorization - **important**
       
            app.UseAuthentication(); 

            app.UseAuthorization(); //Authorisation - needs configured

            app.UseEndpoints(endpoints => //Middlewear end points
            {
                endpoints.MapControllers(); //Map Controllers
            });
        }
    }
}
