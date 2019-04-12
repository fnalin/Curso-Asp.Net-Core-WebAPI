using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FN.Store.DI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;

namespace FN.Store.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => {

                // forçar a api a dar o erro 406
                options.ReturnHttpNotAcceptable = true;

                options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            })
                .AddJsonOptions(options => {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                });
            services.AddDependencies();

            services.AddSwaggerGen(s => {
                s.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Store API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(s => {
                s.SwaggerEndpoint("swagger/v1/swagger.json", "Store API");
                s.RoutePrefix = string.Empty;
            });
        }
    }
}
