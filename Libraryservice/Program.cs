using Libraryservice.Models;
using Libraryservice.Services;
using Libraryservice.Services.Impl;
using Microsoft.AspNetCore.HttpLogging;
using NLog.Web;


namespace Libraryservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region Configure logging service

            builder.Services.AddHttpLogging(logging =>
            {
                logging.LoggingFields = HttpLoggingFields.All | HttpLoggingFields.RequestQuery;
                logging.RequestBodyLogLimit = 4096;
                logging.ResponseBodyLogLimit = 4096;
                logging.RequestHeaders.Add("Authorization");
                logging.RequestHeaders.Add("X-Real-IP");
                logging.RequestHeaders.Add("X-Forwarded-For");
            });

            builder.Host.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();

            }).UseNLog(new NLogAspNetCoreOptions() { RemoveLoggerFactoryFilter = true });

            #endregion

            #region Configure Options Services

            builder.Services.Configure<DatabaseOptions>(options =>
            {
                builder.Configuration.GetSection("Settings:DatabaseOptions").Bind(options);
            });

            #endregion

            #region Configure Repository Services

            builder.Services.AddScoped<ILabraryRepositoryService, LibraryRepository>();

            #endregion

            #region Configure Database Service

            builder.Services.AddSingleton<ILibraryDatabaseContextService, LibraryDatabaseContext>();

            #endregion


            //builder.Services.AddControllers();
            builder.Services.AddControllersWithViews(); // MVC Support

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            // MVC Support
            else
            {
                app.UseExceptionHandler("/Library/Error");
            }

            // MVC Support
            app.UseStaticFiles();

            app.UseHttpLogging();

            app.UseRouting();

            app.UseAuthorization();

            // MVC Support
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Library}/{action=Index}/{id?}");
            });



            app.Run();
        }
    }
}