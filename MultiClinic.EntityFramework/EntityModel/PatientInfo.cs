using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiClinic.EntityFramework.EntityModel
{
    public class PatientInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientInfoId { get; set; }
        [Required,StringLength(100)]
        public string PatientName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }        
        [StringLength(50)]
        public string NRC { get; set; }
        [Required, StringLength(20)]
        public string Gender { get; set; }
        [Required, StringLength(50)]
        public string PatientPhone { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [Required, StringLength(200)]
        public string Address { get; set; }
        [StringLength(100)]
        public string GuardianName { get; set; }
        [StringLength(50)]
        public string GuardianPhone { get; set; }
        public string Notes { get; set; }
        [StringLength(20)]
        public string PatientType { get; set; }


    }
}
