using Auth0.AspNetCore.Authentication;
using Event_Management.Models;
using Event_Management.MongodbContext;
using Event_Management.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;

namespace Event_Management
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
            services.Configure<DatabaseSettings>(
           Configuration.GetSection(nameof(DatabaseSettings)));

            services.AddSingleton<IDatabaseSettings>(sp =>
             sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);
            services.AddSingleton<EventService>();

            var mongoDbSetting = Configuration.GetSection(nameof(DatabaseSettings)).Get<DatabaseSettings>();
            services.AddIdentity<ApplicationUser, ApplicationRole>().AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>(
                mongoDbSetting.ConnectionString, mongoDbSetting.DatabaseName);
            
            services.ConfigureSameSiteNoneCookies();

            services.AddAuth0WebAppAuthentication(options => {
                options.Domain = Configuration["Auth0:Domain"];
                options.ClientId = Configuration["Auth0:ClientId"];
                options.Scope = "openid profile email";
            });

            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();

            services.AddSession();

            services.AddControllersWithViews();

            services.AddSwaggerGen(x => { x.SwaggerDoc("v1", new OpenApiInfo { Title = "Class Reminder Application API", Version = "v1" }); });

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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
