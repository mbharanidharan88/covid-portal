using CovidPortal.Business;
using CovidPortal.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidPortal.HospitalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HospitalController : ControllerBase
    {
        #region Fields

        private readonly IHospitalBusiness _hospitalBusiness;
        private readonly ILogger<HospitalController> _logger;


        #endregion

        #region Constructor

        public HospitalController(IHospitalBusiness hospitalBusiness,
            ILogger<HospitalController> logger)
        {
            _hospitalBusiness = hospitalBusiness;
            _logger = logger;
        }

        #endregion

        #region API Methods

        [HttpGet]
        public async Task<IEnumerable<Hospital>> Get()
        {
            return await _hospitalBusiness.GetAllHospitals();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Hospital> Get([FromRoute] int id)
        {
            return await _hospitalBusiness.GetHospitalById(id);
        }

        [HttpPost]
        public async Task Post([FromBody] Hospital hospital)
        {
            await _hospitalBusiness.AddHospital(hospital);
        }

        #endregion
    }
}
