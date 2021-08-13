using System;
using System.Text;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Yyuri.Data.EntityFramework;
using Yyuri.Build;

namespace Ats.Build
{
    public class Program
    {
        public static IConfigurationRoot Configuration;

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            //string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            //if (String.IsNullOrWhiteSpace(environment))
            //    throw new ArgumentNullException("Environment not found in ASPNETCORE_ENVIRONMENT");

            //Console.WriteLine("Environment: {0}", environment);

            try
            {
                // Set up configuration sources.
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                    .AddJsonFile("appsettings.json", optional: true);

                Configuration = builder.Build();

                Console.WriteLine("Path: {0}", Path.Combine(AppContext.BaseDirectory));

                var connectionString = Configuration.GetConnectionString("DataAccessSqlProvider");
                Console.WriteLine("Connection String: {0}", connectionString);

                var optionsBuilder = new DbContextOptionsBuilder<SCDataContext>();
                optionsBuilder.UseSqlServer(connectionString);

                AppIdentityDbContext dbContext = new AppIdentityDbContext(optionsBuilder.Options);

                using (var context = new AppIdentityDbContext(optionsBuilder.Options))
                {
                    context.EnsureSeedDataForContext();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");

                if(ex.InnerException != null)
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");

                throw ex;
            }

            Console.WriteLine("Data Migration Done!");
        }
    }
}

/* ***** READ ME

    // Update Database
    // Set project start to Ats.Web (as default)
    // Set default project (in PMC) to Ats.Build
    update-database -context AppIdentityDbContext

    // Seeding Data
    bin/Debug/netcore/dotnet Ats.Build.dll

    Reset DB
    Update-Database -Migration 0 -context AppIdentityDbContext

    // Add migration
    //add-migration "file-name" -context AppIdentityDbContext 

*/
