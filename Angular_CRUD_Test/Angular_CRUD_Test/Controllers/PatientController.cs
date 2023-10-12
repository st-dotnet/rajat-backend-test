using Angular_CRUD_Test.Models;
using Angular_CRUD_Test.Services;
using Microsoft.AspNetCore.Mvc;

namespace Angular_CRUD_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientServices _patientServices;

        public PatientController(IPatientServices patientServices)
        {
            _patientServices = patientServices;
        }
        
        [HttpPost]
        [Route("getAll")]
        public IActionResult GetAllPatients([FromBody] Search search)
        {
            var patients = _patientServices.GetAllPatients(search.searchByFirstName);
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public IActionResult GetPatientById(int id)
        {
            var patient = _patientServices.GetPatientById(id);
            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

        [HttpPost]
        public IActionResult AddPatient([FromBody] PatientReqModel patient)
        {
            _patientServices.AddPatient(patient);
            return CreatedAtAction(nameof(GetPatientById), new { id = patient.id }, patient);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, [FromBody] PatientReqModel patient)
        {
            var existingPatient = _patientServices.GetPatientById(id);
            if (existingPatient == null)
                return NotFound();

            patient.id = id;
            _patientServices.UpdatePatient(patient);
            return Ok(patient);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var existingPatient = _patientServices.GetPatientById(id);
            if (existingPatient == null)
                return NotFound();
            _patientServices.DeletePatient(id);
            return NoContent();
        }

    }
}
