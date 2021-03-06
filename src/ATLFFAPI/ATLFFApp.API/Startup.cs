﻿using ATLFFApp.API.Data;
using ATLFFApp.API.Repositories;
using ATLFFApp.API.Repositories.Neo4j;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace ATLFFApp.API
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
            services.AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddJsonOptions(options => options.SerializerSettings.ContractResolver =
                    new DefaultContractResolver());

            // return data from appsetings - url - user - pass 
            services.Configure<AtlffSettings>(Configuration.GetSection("AtlffSettings"));

            // pass the above setings to client connection Neo4j DB
            services.AddSingleton<IGraphRepository, GraphRepository>();

            // available queries for controllers
            services.AddSingleton<ICityRepository, CityRepository>();

            // connection to MSQLS Server
            services.AddDbContext<ShipmentContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddSwaggerGen(options => options.SwaggerDoc("v1", new Info { Title = "Advanced Transport and Logistics – Freight Forwarding (ATL-FF)", Version = "v1" })
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            if (env.IsDevelopment() || env.IsStaging())
            {

                app.UseSwaggerUI(options =>
                        options.SwaggerEndpoint("/swagger/v1/swagger.json", "ATL-FF v1")
                );

            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
