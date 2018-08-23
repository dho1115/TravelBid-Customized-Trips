﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CustomizedTrips.Data;
using CustomizedTrips.Models;
using CustomizedTrips.Services;
using Braintree;

namespace CustomizedTrips
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));



            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();



            // Add application services. //CHANGES
            //services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IEmailSender>((IServiceProvider) => new EmailSender(Configuration.GetValue<string>("SendGrid.ApiKey")));

            
            services.AddTransient<Braintree.IBraintreeGateway>((iServiceProvider) => new Braintree.BraintreeGateway(
                Configuration.GetValue<string>("Braintree.Environment"),
                Configuration.GetValue<string>("Braintree.MerchantId"),
                Configuration.GetValue<string>("Braintree.PublicKey"),
                Configuration.GetValue<string>("Braintree.PrivateKey")
                )); 


            //services.AddMvc();
            services.AddMvc(options => {
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {          
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
