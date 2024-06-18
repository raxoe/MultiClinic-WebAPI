using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiClinic.DataAccess.Implementation;
using MultiClinic.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiClinic.DataAccess
{
    public class DataAccessDI
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<IPatientInfoRepository, PatientInfoRepository>();            
        }
    }
}
