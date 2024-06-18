using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiClinic.Model.DTO
{
    public class PatientInfoModel
    {
        public int PatientInfoId { get; set; }
        public string PatientName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NRC { get; set; }
        public string Gender { get; set; }
        public string PatientPhone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string GuardianName { get; set; }
        public string GuardianPhone { get; set; }
        public string Notes { get; set; }
        public string PatientType { get; set; }
    }
}
