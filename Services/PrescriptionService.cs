using MedicalAPI.Context;
using MedicalAPI.Models;
using MedicalAPI.Requests;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalAPI.Services
{
    public class PrescriptionService
    {
        private readonly ApplicationContext _context;

        public PrescriptionService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<(bool Success, string Message, Prescription? Prescription)> AddPrescriptionAsync(AddPrescriptionRequest request, CancellationToken cancellationToken)
        {
            var patient = await _context.Patients.FindAsync(new object[] { request.IdPatient }, cancellationToken) 
                          ?? new Patient
                          {
                              FirstName = request.PatientFirstName,
                              LastName = request.PatientLastName,
                              Birthdate = request.PatientBirthdate
                          };

            var doctor = await _context.Doctors.FindAsync(new object[] { request.IdDoctor }, cancellationToken);
            if (doctor == null)
            {
                return (false, "Doctor not found.", null);
            }

            var prescription = new Prescription
            {
                Date = request.Date,
                DueDate = request.DueDate,
                Patient = patient,
                Doctor = doctor,
                PrescriptionMedicaments = new List<PrescriptionMedicament>()
            };

            foreach (var med in request.Medicaments)
            {
                var medicament = await _context.Medicaments.FindAsync(new object[] { med.IdMedicament }, cancellationToken);
                if (medicament == null)
                {
                    return (false, $"Medicament with ID {med.IdMedicament} not found.", null);
                }

                prescription.PrescriptionMedicaments.Add(new PrescriptionMedicament
                {
                    Medicament = medicament,
                    Dose = med.Dose,
                    Details = med.Description
                });
            }

            if (prescription.DueDate < prescription.Date)
            {
                return (false, "DueDate must be greater than or equal to Date.", null);
            }

            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync(cancellationToken);

            return (true, "Prescription added successfully.", prescription);
        }
    }
}
