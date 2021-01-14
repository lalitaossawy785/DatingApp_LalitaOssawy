using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    //Static means we do not need to create a new instances of this class in order to use it
    public static class ApplicationServiceExtensions //Create static method
    {
        //We tell the new static method what we want it to return from the extension
        //Always specific 'this' before specifying the type you're extending
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config) 
        {
               //Reason for interface is best for testing as it makes it easier - best practice
            services.AddScoped<ITokenService, TokenService>(); //Appropiate for HTTP Request 
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection")); //Connect to dB based on this specific connection string
            });

            return services; //returning services
        }
    }
}