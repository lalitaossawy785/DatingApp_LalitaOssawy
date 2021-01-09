using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        public static void Main(string[] args) //Main method, looks for this and runs this
        {
            CreateHostBuilder(args).Build().Run(); //Calls another method, 'CreateHostBuilder'
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => //Intalises the host builder class 
            Host.CreateDefaultBuilder(args) //Get configure from event variables 
                .ConfigureWebHostDefaults(webBuilder => //Returns intialised host builder
                {
                    webBuilder.UseStartup<Startup>(); //Also use 'StartUp' class
                });
    }
}
