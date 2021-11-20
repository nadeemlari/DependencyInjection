using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace DependencyInjection
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
            services.AddControllers();

            //this is a lot of code 
            //var item  =  new ServiceDescriptor(typeof(IOperationTransient), a => new Operation(),
            //    ServiceLifetime.Transient);
            //services.Add(item);

            services.AddTransient<IOperationTransient, Operation>();
            services.AddScoped<IOpertionScoped, Operation>();
            services.AddSingleton<IOperationSingleton, Operation>();
            services.AddSingleton<IOperationSingletonInstance>(_ => new Operation(Guid.Empty));
            services.TryAddSingleton<IOperationSingletonInstance>(_ => new Operation());
            services.AddTransient<DependencyService1, DependencyService1>();
            services.AddTransient<DependencyService2, DependencyService2>();    
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
