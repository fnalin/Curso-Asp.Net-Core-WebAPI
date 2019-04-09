using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreHelloWorld
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            //app.UseMvc();
            app.UseMvcWithDefaultRoute();

            app.Use(async (ctx, next) =>
            {
                ctx.Response.ContentType = "text/plain;charset=utf-8";
                await ctx.Response.WriteAsync("Execução Inicial ");
                await next.Invoke();
                await ctx.Response.WriteAsync("Execução final ");
            });

            app.Map("/map1", HandleMap1);
            app.Map("/map2", HandleMap2);

            // app.MapWhen(ctx => true, HandleMapWhen);
            app.MapWhen(ctx => false, HandleMapWhen);


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Bateu no final ");
            });


        }

        private void HandleMapWhen(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Bateu no run do MapWhen ");
            });
        }

        private void HandleMap2(IApplicationBuilder app)
        {
            app.Use(async (ctx, next) =>
            {
                await ctx.Response.WriteAsync("Execução Inicial do Map2 ");
                await next.Invoke();
                await ctx.Response.WriteAsync("Execução Final do Map2 ");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Bateu no run do Map2 ");
            });
        }

        private void HandleMap1(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Bateu no run do Map1 ");
            });
        }
    }
}
