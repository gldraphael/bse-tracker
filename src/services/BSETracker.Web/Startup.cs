using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSETracker.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BSETracker.Web
{
    public class Startup
    {
        IConfiguration config;
        public Startup(IConfiguration config) {
            this.config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddNodeServices();
            services.AddDbContext<AppDbContext>(optons => {
                optons.UseNpgsql(config.GetConnectionString("Database"));
            });

            services.AddHttpClient<BseClient>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseForwardedHeaders(new ForwardedHeadersOptions
            // {
            //     ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            // });
            // app.UseAuthentication();

            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
