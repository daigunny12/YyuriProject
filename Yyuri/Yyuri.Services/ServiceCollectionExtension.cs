using Microsoft.Extensions.DependencyInjection;
using Yyuri.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Yyuri.Services.Extensions;
using Yyuri.Services.EmailEngine;

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
            services.AddScoped<IEmailService, EmailService>();
            //---------------------------------Image Helper---------------------------------------
            services.AddScoped<IAccountService, AccountService>();


            return services;
        }
    }
}
