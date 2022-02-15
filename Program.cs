<<<<<<< HEAD
<<<<<<< HEAD
using Auth0.AspNetCore.Authentication; // 👈 new code

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddAuth0WebAppAuthentication(options => {
      options.Domain = builder.Configuration["Auth0:Domain"];
      options.ClientId = builder.Configuration["Auth0:ClientId"];
    });
// 👆 new code

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
=======
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Event_Management
>>>>>>> c361744cd1734c1ff96d614ac68102f056614386
=======
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace classReminder
>>>>>>> parent of c524215 (changes made for all the files)
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
