using Microsoft.AspNetCore.Mvc;

using MultiClinic.DataAccess.Interface;
using MultiClinic.Model.DTO;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiClinic.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IPatientInfoRepository _patientInfoRepository;

        public PatientController(ILogger<PatientController> logger, IPatientInfoRepository patientInfoRepository)
        {
            _logger = logger;
            _patientInfoRepository = patientInfoRepository;
        }

        // GET: api/<PatientController>
        [HttpGet]
        public ActionResult<IEnumerable<PatientInfoModel>> Get()
        {
            try
            {
                IEnumerable<PatientInfoModel> lstPatientInfoModel = _patientInfoRepository.GetAllPatienInfo();
                if (!lstPatientInfoModel.Any())
                {
                    return NoContent();
                }
                // Add a custom header
                //Response.Headers.Add("X-Custom-Header", "foo");
                return Ok(lstPatientInfoModel);

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public ActionResult<PatientInfoModel> Get(int id)
        {
            try
            {
                PatientInfoModel patientInfoModel = _patientInfoRepository.GetPatientInfo(id);
                if (patientInfoModel == null)
                {
                    return NotFound();
                }
                return Ok(patientInfoModel);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // POST api/<PatientController>
        [HttpPost]
        public ActionResult<PatientInfoModel> Post([FromBody] PatientInfoModel patientInfoModel)
        {
            try
            {
                if (patientInfoModel == null)
                {
                    return BadRequest();
                }
                var createdPatient = _patientInfoRepository.AddPatientInfo(patientInfoModel);

                return CreatedAtAction(nameof(Get), new { id = createdPatient.PatientInfoId }, createdPatient);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PatientInfoModel patientInfoModel)
        {
            try
            {
                if (patientInfoModel == null || id != patientInfoModel.PatientInfoId)
                {
                    return BadRequest();
                }

                var result = _patientInfoRepository.UpdatePatienInfo(patientInfoModel);
                if (!result)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = _patientInfoRepository.DeletePatienInfo(id);
                if (!result)
                {
                    return NotFound();
                }                

                return NoContent();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
