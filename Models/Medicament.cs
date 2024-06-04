using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MedicalAPI.Models
{
    [Table("medicament")]
    public class Medicament
    {
        [Key]
        public int IdMedicament { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [StringLength(100)]
        public string Type { get; set; }

        [JsonIgnore]
        public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    }
}