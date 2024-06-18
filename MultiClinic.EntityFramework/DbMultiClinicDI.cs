using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiClinic.EntityFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiClinic.EntityFramework
{
    public static class DbMultiClinicDI
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration Configuration,string connectionString)
        {
            //services.AddDbContext<DbMultiClinicContext>(options =>
            //    options.UseSqlServer("name=ConnectionStrings:DbMultiClinic"));
            services.AddDbContext<DbMultiClinicContext>(options =>
                options.UseSqlServer($"name=ConnectionStrings:{connectionString}"));

            services.AddDatabaseDeveloperPageExceptionFilter();

        }

        public static void MigrateDatabase(IServiceScope scope)
        {
            var dbContextOptions = scope.ServiceProvider.GetRequiredService<DbMultiClinicContext>();
            dbContextOptions.Database.Migrate();

            DbMultiClinicInitializer.Initialize(dbContextOptions);
        }

        public static void DbEnsureCreate(IServiceScope scope)
        {
            var context = scope.ServiceProvider.GetRequiredService<DbMultiClinicContext>();
            context.Database.EnsureCreated();
        }
    }
}
