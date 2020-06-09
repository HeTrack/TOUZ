using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TourSearchAggregator;
using TourSearchCommon.Services;
using TourSearchImitator;

namespace TourSearchWebApi
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
            services
                .AddControllers()
                .AddNewtonsoftJson();

            services.AddSwaggerDocument();

            var imitationDict = ImitatorService.ImitateDict();

            services.AddSingleton<TourSearchTuiProvider.Storages.MemoryDictStorage>(new TourSearchTuiProvider.Storages.MemoryDictStorage(imitationDict));
            services.AddScoped<IDictService, TourSearchTuiProvider.Services.MemoryDictService>();

            services.AddSingleton<TourSearchTuiProvider.Storages.MemoryTourStorage>(
                new TourSearchTuiProvider.Storages.MemoryTourStorage(ImitatorService.ImitateTours("Tui", imitationDict)));
            services.AddScoped<ISearchService, TourSearchTuiProvider.Services.MemorySearchService>();

            services.AddSingleton<TourSearchOtherProvider.Storages.MemoryTourStorage>(
                new TourSearchOtherProvider.Storages.MemoryTourStorage(ImitatorService.ImitateTours("Other", imitationDict)));
            services.AddScoped<ISearchService, TourSearchOtherProvider.Services.MemorySearchService>();

            services.AddScoped<AggregatorService, AggregatorService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });



        }
    }
}