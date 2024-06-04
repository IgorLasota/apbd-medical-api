using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAPI.Models
{
    [Table("prescription_medicament")]
    public class PrescriptionMedicament
    {
        public int IdMedicament { get; set; }
        public int IdPrescription { get; set; }

        public double Dose { get; set; }

        [StringLength(100)]
        public string Details { get; set; }

        [ForeignKey("IdMedicament")]
        public Medicament Medicament { get; set; }

        [ForeignKey("IdPrescription")]
        public Prescription Prescription { get; set; }
    }
}