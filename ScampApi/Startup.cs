using System;
using System.Linq;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using Newtonsoft.Json.Serialization;
using ScampApi.Infrastructure;
using Microsoft.AspNet.StaticFiles;

namespace ScampApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Setup configuration sources.
            Configuration = new Configuration()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables("APPSETTING_");

        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by a runtime.
        // Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.Configure<MvcOptions>(options=> {
                var jsonFormatter = (JsonOutputFormatter)(options.OutputFormatters
                    .First(formatter => formatter.Instance is JsonOutputFormatter)
                    .Instance);
                jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                //options.Filters.Add(new RequireHttpsAttribute());

            });

            services.AddTransient<ILinkHelper, LinkHelper>();

            services.AddInstance(Configuration);
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseOAuthBearerAuthentication(options =>
            {
                options.Audience = Configuration.Get("ClientId");
                options.Authority = String.Format(Configuration.Get("AadInstance"), Configuration.Get("TenantId"));
            });

            //app.UseStaticFiles();
            // Add MVC to the request pipeline.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
                
            });
        }
    }
}
