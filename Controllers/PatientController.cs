using MedicalAPI.Responses;
using MedicalAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalAPI.Controllers
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientService _patientService;

        public PatientController(PatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetPatient(int patientId, CancellationToken cancellationToken)
        {
            var patient = await _patientService.GetPatientAsync(patientId, cancellationToken);
            if (patient == null)
            {
                return NotFound("Patient not found.");
            }

            return Ok(patient);
        }
    }
}