using BusinessLayer;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NJsonSchema;
using NSwag.AspNetCore;
using System.Reflection;
using WebLayer.ExceptionFilter;

namespace WebLayer
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
            services.AddMvc(o => { o.Filters.Add<GlobalExceptionFilter>(); });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddRouting();
            services.AddSwaggerDocument();

            //services.AddSwaggerGen(c =>
            //            {
            //                c.EnableAnnotations();
            //                c.SwaggerDoc("v1", new Info { Title = "#And API", Version = "v1" });

            //                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
            //                var xmlPath = Path.Combine(basePath, "Cyberkruz.Autorest.Web.xml");
            //                c.IncludeXmlComments(xmlPath);
            //            });
            //services.AddScoped<ClientDbContext>(_ => new ClientDbContext(Configuration.GetConnectionString("HotelsDatabase")));
            services.AddDbContext<ClientDbContext>(options =>

                options.UseSqlServer(Configuration.GetConnectionString("HotelsDatabase"))
            );
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRezervationService, RezervationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/error/{0}");
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseStaticFiles();
            app.UseSwaggerUi3(typeof(Startup).GetTypeInfo().Assembly, settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling =
                                  PropertyNameHandling.CamelCase;
            });
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            //    c.RoutePrefix = string.Empty;
            //});
            app.UseMvc();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}