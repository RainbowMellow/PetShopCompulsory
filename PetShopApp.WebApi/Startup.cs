using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PetShop.Core.ApplicationServices;
using PetShop.Core.ApplicationServices.Impl;
using PetShop.Core.DomainServices;
using PetShop.Core.Validators;
using PetShop.Core.Validators.Impl;
using PetShop.Infrastructure.DBInitialization;
using PetShop.Infrastructure.SQLite.Data;
using PetShop.Infrastructure.SQLite.Data.Repositories;

namespace PetShopApp.WebApi
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
            services.AddDbContext<PetShopContext>(
                opt => opt.UseSqlite("Data Source = PetShop.db")
                );



            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<INewInputValidators, NewInputValidators>();
            services.AddScoped<IPetTypeRepository, PetTypeRepository>();
            services.AddScoped<IPetTypeService, PetTypeService>();

            services.AddControllers().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                o.SerializerSettings.MaxDepth = 5;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetShopContext>();
                    ctx.Database.EnsureDeleted();
                    ctx.Database.EnsureCreated();
                    var petRepository = scope.ServiceProvider.GetService<IPetRepository>();
                    var ownerRepository = scope.ServiceProvider.GetService<IOwnerRepository>();
                    var petTypeRepository = scope.ServiceProvider.GetService<IPetTypeRepository>();
                    new DBInitializer(petRepository, ownerRepository, petTypeRepository).InitData();
                }
            }


            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var repo = scope.ServiceProvider.GetService<IPetRepository>();
                    //FakeDB.InitData();
                }
            //}

            



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
