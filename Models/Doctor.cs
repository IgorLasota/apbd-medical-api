using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MedicalAPI.Models
{
    [Table("doctor")]
    public class Doctor
    {
        [Key]
        public int IdDoctor { get; set; }

        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [Required, StringLength(100)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string Email { get; set; }
        
        [JsonIgnore]
        public ICollection<Prescription> Prescriptions { get; set; }
    }
}