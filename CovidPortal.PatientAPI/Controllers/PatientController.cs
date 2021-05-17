using CovidPortal.Business;
using CovidPortal.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CovidPortal.PatientAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        #region Fields

        private readonly IPatientBusiness _patientBusiness;
        private readonly ILogger<PatientController> _logger;
        

        #endregion

        #region Constructor

        public PatientController(IPatientBusiness patientBusiness,
            ILogger<PatientController> logger)
        {
            _patientBusiness = patientBusiness;
            _logger = logger;
        }

        #endregion

        #region API Methods

        [HttpGet]
        public async Task<IEnumerable<Patient>> Get()
        {
            return await _patientBusiness.GetAllPatients();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Patient> Get([FromRoute] int id)
        {
            return await _patientBusiness.GetPatientById(id);
        }

        [HttpPost]
        public async Task Post([FromBody] Patient patient)
        {
            await _patientBusiness.AddPatient(patient);
        }

        #endregion
    }
}
