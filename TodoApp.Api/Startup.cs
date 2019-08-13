using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TodoApp.Domain.TodoAppContext.Handlers;
using TodoApp.Domain.TodoAppContext.Repositories;
using TodoApp.Domain.TodoAppContext.Services;
using TodoApp.Infra.TodoAppContext;
using TodoApp.Infra.TodoAppContext.Repositories;
using TodoApp.Infra.TodoAppContext.Services;
using Microsoft.Extensions.Configuration;
using System.IO;
using TodoApp.Shared;

namespace TodoApp.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            //add package.json //dotnet add package Microsoft.Extensions.Configuration.Json
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("settings.json");

            Configuration = builder.Build();

            services.AddMvc();

            //add compression: //dotnet add package Microsoft.AspNetCore.ResponseCompression 
            //services.AddResponseCompression();

            services.AddScoped<TodoAppDataContext, TodoAppDataContext>();
            services.AddTransient<ITodoTaskRepository, TodoTaskRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<TodoTaskHandler, TodoTaskHandler>();

            //documente api - project api:
            //dotnet add package Swashbuckle.AspNetCore
            //services.AddSwaggerGen(x => {
            //  x.SwaggerDoc("v1", new Info { Title = "Todo App", Version = "V1" })
            //});

            Settings.ConnectionString = $"{Configuration["connectionString"]}";
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();


            app.UseMvc();

            //app.UseResponseCompression();

            //app.UseSwagger();
            //app.UseSwaggerUI(c => {
            //  c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApp V1");
            //});
        }
    }
}