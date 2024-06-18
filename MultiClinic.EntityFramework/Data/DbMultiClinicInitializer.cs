using MultiClinic.Common.Enum;
using MultiClinic.EntityFramework.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MultiClinic.EntityFramework.Data
{
    public static class DbMultiClinicInitializer
    {
        public static void Initialize(DbMultiClinicContext context)
        {
            // Look for any students.
            if (context.PatientInfos.Any())
            {
                return;   // DB has been seeded
            }

            var patientInfos = new PatientInfo[]
            {
                new PatientInfo{PatientName="Patien1", DateOfBirth = DateTime.Now.AddYears(-20), NRC = "12/ISN-007007", Gender = Gender.Male.ToString(), PatientPhone = "+65 12345678", Email = "test@hot.com", Address = "007 Demi St, Demi Township, Demi State, Demi Country", GuardianName = "Mr.Senior", GuardianPhone ="+95 123456789", Notes = "Testing remarks", PatientType = PatientType.Regular.ToString()  },
                new PatientInfo{PatientName="Patien2", DateOfBirth = DateTime.Now.AddYears(-20), NRC = "12/ISN-007008", Gender = Gender.Female.ToString(), PatientPhone = "+65 12345678", Email = "test@hot.com", Address = "007 Demi St, Demi Township, Demi State, Demi Country", GuardianName = "Mr.Senior", GuardianPhone ="+95 123456789", Notes = "Testing remarks", PatientType = PatientType.VIP.ToString() }
            };

            context.PatientInfos.AddRange(patientInfos);
            context.SaveChanges();

        }
    }
}
