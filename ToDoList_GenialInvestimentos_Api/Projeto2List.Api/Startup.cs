using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Projeto2List.Api.Data;
using Projeto2List.Api.Repositories;
using Projeto2List.Api.Repositories.Interfaces;

namespace Projeto2List.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<StoreDataContext, StoreDataContext>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<INotaTarefaRepository, NotaTarefaRepository>();
            services.AddResponseCompression();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
            app.UseResponseCompression();
        }
    }
}
