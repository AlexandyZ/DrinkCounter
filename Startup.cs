using DrinkCounter.Models;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DrinkCounter
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = "Server=drinkcounter.database.windows.net;Database=DrinkCounterData;User ID=drink;Password=Antl123!;Trusted_Connection=False;Connect Timeout=30;Encrypt=True;MultipleActiveResultSets=False";
            services.AddCors();
            // Add framework services.
            services.AddMvc();
            services.AddEntityFramework()
                    .AddSqlServer()
                    .AddDbContext<DrinkingData>(options => options.UseSqlServer(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors(builder =>
                            builder.WithOrigins("http://localhost:5000")
                                   .AllowAnyHeader());

            app.UseIISPlatformHandler();

            app.UseStaticFiles();

            app.UseMvc();


        }

        // Entry point for the application.
        public static void Main(string[] args) => Microsoft.AspNet.Hosting.WebApplication.Run<Startup>(args);
    }
}
