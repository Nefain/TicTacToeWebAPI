using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tic_Tac_ToeWebAPI.Storage;

namespace Tic_Tac_ToeWebAPI
{
    public class Startup
    {
        IConfigurationRoot configurationRoot;

        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment configuration)
        {
            configurationRoot = new ConfigurationBuilder().SetBasePath(configuration.ContentRootPath).AddJsonFile("appsettings.json").Build();
        }
        

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddEntityFrameworkSqlite().AddDbContext<AutoDataContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Calc}/{action=MainPage}");
            });
        }
    }
}
