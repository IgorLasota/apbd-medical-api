using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MedicalAPI.Models
{
    [Table("prescription")]
    public class Prescription
    {
        [Key]
        public int IdPrescription { get; set; }

        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }

        [ForeignKey("Patient")]
        public int IdPatient { get; set; }
        

        [ForeignKey("Doctor")]
        public int IdDoctor { get; set; }
        
        public Doctor Doctor { get; set; }
        
        [JsonIgnore]
        public Patient Patient { get; set; }
        
        public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    }
}