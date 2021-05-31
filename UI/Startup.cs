using System;
using Application.Interfaces.ExmDto;
using Application.Interfaces.General;
using Application.Services;
using IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using Newtonsoft.Json;
using Persistence;
using Persistence.Repositories;
using Xunit;

namespace UI
{
    public class Startup
    {
        private readonly IHostEnvironment _env;

        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            _env = env;
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterJwtAuthentication(services);

            RegisterSwagger(services);

            RegisterServices(services);

            RegisterFilterAction(services);

            //var ConnectionString = Configuration.GetConnectionString("GQConnection");
            ConnectionString = Configuration.GetConnectionString("CurrentConnection");
            if (string.IsNullOrEmpty(ConnectionString))
                throw new InvalidOperationException("The connection string was not set " +
                                                    "in the 'EFCORETOOLSDB' environment variable.");

            services.AddSingleton<IMongoClient, MongoClient>(x =>
                new MongoClient(Configuration.GetConnectionString("MongoConnection")));

            services.AddSingleton<IExamMongoRepository>(x =>
                new ExamMongoRepository(x.GetRequiredService<IMongoClient>(),
                    "Goldenquestion",
                    "Exam"));


            services.AddDbContext<ApiContext>(options =>
                options.UseSqlServer(ConnectionString,
                    optionsBuilder =>
                        optionsBuilder.MigrationsAssembly("UI")
                )
            );
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/dist"; });

            services.AddCors(options => options.AddPolicy("Cors", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                );
        }

        public string ConnectionString { get; set; }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseExceptionHandler("/error-local-development");
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseSpaStaticFiles();
                //app.UseExceptionHandler("/Error/{statusCode}");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("Cors");

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            // Use Swagger ------------------------------------
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"); });
            //------------------------------------


            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                    spa.UseAngularCliServer("start");
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUtilities, Utilities>();
            //services.AddScoped<IMongoRepository<ExamMongo>, MongoRepository<ExamMongo>>();
            DependencyContainer.RegisterServices(services);
        }

        private  void RegisterSwagger(IServiceCollection services)
        {
            var backendVersion = Configuration["BackendVersion"];
            SwaggerContainer.RegisterSwagger(services, backendVersion);
        }

        private void RegisterJwtAuthentication(IServiceCollection services)
        {
            var token = Configuration["AppSettings:Token"];
            JwtContainer.RegisterJwtAuthentication(services, token);
        }

        private static void RegisterFilterAction(IServiceCollection services)
        {
            FilterActionContainer.FilterActionServices(services);
        }

        
    }
}