using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalAPI.Requests
{
    public class AddPrescriptionRequest
    {
        [Required]
        public int IdPatient { get; set; }

        [Required]
        public string PatientFirstName { get; set; }

        [Required]
        public string PatientLastName { get; set; }

        [Required]
        public DateTime PatientBirthdate { get; set; }

        [Required]
        public int IdDoctor { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public List<MedicamentRequest> Medicaments { get; set; }
    }
}
