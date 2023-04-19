using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PromactMessagingApp.DomainModel.ApplicationClasses.UserAC;
using PromactMessagingApp.DomainModel.DbContexts;
using PromactMessagingApp.DomainModel.Models.User;
using PromactMessagingApp.Repository.Data;
using PromactMessagingApp.Repository.User;
using Swashbuckle.AspNetCore.SwaggerUI;
using Newtonsoft.Json.Converters;
using PromactMessagingApp.Repository.Login;
using PromactMessagingApp.DomainModel.ApplicationClasses.LoginAC;
using PromactMessagingApp.DomainModel.Models.Login;
using PromactMessagingApp.Core.Hubs;
using System;
using PromactMessagingApp.Repository.Messages;
using PromactMessagingApp.DomainModel.ApplicationClasses.MessagesAC;
using PromactMessagingApp.DomainModel.Models.Message;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNet.SignalR;

namespace Promact_Messaging_Application
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

            services.AddControllers().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.Converters.Add(new StringEnumConverter());
            });

            services.AddScoped<IDataRepository, DataRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IMessagesRepository, MessagesRepository>();
            services.AddDbContext<MessagingDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "WEB API",
                    Version = "v1"
                });
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie();
            services.AddAutoMapper(cfg =>
           {
               cfg.CreateMap<UserAC, UserInformation>().ReverseMap();
               cfg.CreateMap<UserInformation, UserAC>().ReverseMap();
               cfg.CreateMap<LoginAC, UserLogin>().ReverseMap();
               cfg.CreateMap<MessagesAC, UserMessages>().ReverseMap();

           });
            services.AddSignalR();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {

                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WEB API");
                c.DocumentTitle = "WEB API";
                c.DocExpansion(DocExpansion.List);
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chatHub");
            });
        }
    }
}
