using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientBL.Services;
using PatientBO.Models;
using PatientBO.ViewModels;

namespace PatientAPI.Controllers
{
    /// <summary>
    /// Class serving as controller for handling the requests related to PatientInfos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        /// <summary>
        /// An instance of business logic class
        /// </summary>
        private IPatientService _service;

        public PatientController(IPatientService service)
        {
            _service = service;
        }

        // GET: api/Patient
        [HttpGet]
        public ActionResult<IEnumerable<PatientView>> Get()
        {
            return _service.GetPatients().ToList();
        }

        // GET: api/Patient/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<PatientInfo> Get(int id)
        {
            var patient = _service.GetPatientById(id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        // POST: api/Patient
        [HttpPost]
        public IActionResult Add([FromBody] PatientInfo patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            _service.AddPatient(patient);

            return Created("PatientInfo", patient);
        }

        // PUT: api/Patient/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]  PatientInfo patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            _service.UpdatePatient(id, patient);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeletePatient(id);

            return NoContent();
        }
    }
}