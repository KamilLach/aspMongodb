using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using MongoIntegration.Framework;
using MongoIntegration.Framework.Implementation;
using MongoIntegration.Model;
using MongoIntegration.WebApi.Bootstrap;
using MongoIntegration.WebApi.Payment;
using MongoIntegration.WebApi.Payment.Queries;

namespace MongoIntegration.WebApi
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<DocumentStoreSettings>(Configuration.GetSection("DocumentStore"));
            services.TryAddSingleton<IQueryExecutor, DefaultQueryExecutor>();

            services.TryAddScoped<IDocumentDbContextProvider, DocumentDbContextProvider>();
            services.TryAddScoped(provider => provider.GetService<IDocumentDbContextProvider>().CreateContext());         

            services.TryAddTransient<IQueryHandler<GetAllInvoicesQuery, IEnumerable<Invoice>>, GetAllInvoicesQueryHandler>();
            services.TryAddTransient<IQueryHandler<AddInvoiceQuery, Invoice>, AddInvoiceQueryHandler>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
