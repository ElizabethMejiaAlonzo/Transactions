using Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;
using TransactionAPI.Data;
using TransactionAPI.Handlers;
using TransactionAPI.Services;

namespace TransacctionAPI
{
    public class Startup
    {
        private const string ApiVersion = "v1";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddControllersWithViews()
                .AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("TransactionDB"));
            services.AddTransient<ITransactionManagement, TransactionManagement>();
            services.AddTransient<IBalanceManagement, BalanceManagement>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(ApiVersion, new OpenApiInfo
                {
                    Version = ApiVersion,
                    Title = "Transaction Service",
                    Description = "Transaction Service ASP.NET Core Web API",
                    Contact = new OpenApiContact
                    {
                        Name = "Transaction",
                        Email = string.Empty
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Copyright (c) 2021 ElizabethMejiaAlonzo. All rights reserved."
                    }
                });
            });

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder.AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        );
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint($"/swagger/{ApiVersion}/swagger.json", $"Transaction Service {ApiVersion}");
                options.RoutePrefix = string.Empty;
            });

            app.UseStaticFiles();

            app.UseCors(builder => builder.WithOrigins("*").WithMethods("GET").AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

           app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
