using MedicalAPI.Requests;
using MedicalAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalAPI.Controllers
{
    [Route("api/prescription")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly PrescriptionService _prescriptionService;

        public PrescriptionController(PrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPrescriptionAsync([FromBody] AddPrescriptionRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (request.Medicaments.Count > 10)
            {
                return BadRequest("Prescription cannot contain more than 10 medicaments.");
            }

            if (request.DueDate < request.Date)
            {
                return BadRequest("DueDate must be greater than or equal to Date.");
            }

            var result = await _prescriptionService.AddPrescriptionAsync(request, cancellationToken);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Prescription);
        }
    } 
}