using DataHope.Data;
using Cosmonaut;
using LibraryDataModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MudBlazor.Services;
using Microsoft.JSInterop;

namespace DataHope
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
                .AddAzureAD(options => Configuration.Bind("AzureAd", options));


            services.AddControllersWithViews(options =>
            {
                //var policy = new AuthorizationPolicyBuilder()
                   // .RequireAuthenticatedUser()
                   // .Build();
               // options.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddMudServices();

            // instantiate configuration
            MyConfiguration options = new MyConfiguration();
            Configuration.Bind("MyConfiguration", options);
            services.AddSingleton<MyConfiguration>(options);
            //var _cosmosStoreSettings = new CosmosStoreSettings(options.CosmosDatabaseName, options.CosmosEndpointURL, options.CosmosAPIKey);

            // instantiate user preferences service
            //ICosmosStore<UserPreferencesModel> cosmosStoreUserPreferencesModel = new CosmosStore<UserPreferencesModel>(_cosmosStoreSettings);
            //UserPreferencesService userPreferencesService = new UserPreferencesService(cosmosStoreUserPreferencesModel);
            //services.AddSingleton<UserPreferencesService>(userPreferencesService);


            //// instantiate blog service
            //ICosmosStore<BlogModel> cosmosStoreBlogModel = new CosmosStore<BlogModel>(_cosmosStoreSettings);
            //BlogService blogService = new BlogService(cosmosStoreBlogModel);
            //services.AddSingleton<BlogService>(blogService);

            services.AddSingleton<WeatherForecastService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
