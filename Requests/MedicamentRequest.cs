using System.ComponentModel.DataAnnotations;

namespace MedicalAPI.Requests;

public class MedicamentRequest
{
    [Required]
    public int IdMedicament { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Dose must be a positive number.")]
    public double Dose { get; set; }

    [Required]
    public string Description { get; set; }
}
