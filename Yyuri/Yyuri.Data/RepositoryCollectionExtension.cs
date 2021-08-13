using Yyuri.Data.EntityFramework;
using Yyuri.Data.Repositories;
using Yyuri.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;

namespace Yyuri.Data
{
    public static class RepositoryCollectionExtension
    {
        public static IServiceCollection AddRepositoryCollection(this IServiceCollection services)
        {            
            // services.AddTransient<IMCDataContext>(s => new MCDataContext(options));
            //services.AddScoped(typeof(IMCDataContext), typeof(MCDataContext));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
