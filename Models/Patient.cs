using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MedicalAPI.Models
{
    [Table("patient")]
    public class Patient
    {
        [Key]
        public int IdPatient { get; set; }

        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [Required, StringLength(100)]
        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        [JsonIgnore]
        public ICollection<Prescription> Prescriptions { get; set; }
    }
}