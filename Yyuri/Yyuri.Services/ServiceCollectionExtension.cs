using Microsoft.Extensions.DependencyInjection;
using Yyuri.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Yyuri.Service.EmailEngine;
using Yyuri.Services.Extensions;
namespace Yyuri.Services
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServiceCollection(this IServiceCollection services)
        {
            //services.AddCors( options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder.AllowAnyOrigin()
            //            .AllowAnyMethod()
            //            .AllowAnyHeader()
            //            .AllowCredentials());
            //});

            services.AddSingleton<ILoggerManager, LoggerManager>();

            //---------------------------------Email Service-------------------------------------
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IViewRenderService, ViewRenderService>();
            //---------------------------------Image Helper---------------------------------------
            services.AddScoped<IAccountService, AccountService>();


            return services;
        }
    }
}
