﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Converters;
using Optionals.Samples.NetCore.repository;
using Swashbuckle.Swagger.Model;

namespace Optionals.Samples.NetCore
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Add framework services.
            //           services.AddMvc().AddJsonOptions( o => o.SerializerSettings.Converters.Add(new OptionalConverter()));
            //  services.AddMvc().AddJsonOptions(o => o.SerializerSettings.ContractResolver = new OptionalContractResolver());

            // services.AddJsonFormatters(o => o...);;

            services.AddSwaggerGen();
            services.AddSingleton<IContactRepository, InMemoryContactRepository>();
            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "Options Test Api",
                    Description = "",
                    TermsOfService = "None"
                });
                options.DescribeAllEnumsAsStrings();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors(builder => builder.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod());

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUi();

            
        }


    }
}