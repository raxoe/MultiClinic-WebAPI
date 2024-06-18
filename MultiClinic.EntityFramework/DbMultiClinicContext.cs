using Microsoft.EntityFrameworkCore;
using MultiClinic.EntityFramework.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiClinic.EntityFramework
{
    public class DbMultiClinicContext : DbContext
    {
        public DbMultiClinicContext(DbContextOptions<DbMultiClinicContext> options):base(options)
        {
            
        }
        public DbSet<PatientInfo> PatientInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientInfo>().ToTable("PatientInfo");
        }
    }
}
