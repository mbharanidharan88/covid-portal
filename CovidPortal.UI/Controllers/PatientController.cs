using CovidPortal.Domain.Model;
using CovidPortal.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CovidPortal.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : BaseController
    {
        private readonly ILogger<PatientController> _logger;

        public PatientController(ILogger<PatientController> logger, IConfiguration configuration) : base(configuration)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Patient>> Get()
        {
            try
            {
                //var uri = "Patient";
                var uri = "patient/list";
                var response = await PatientClient.GetAsync(uri);

                if (!response.IsSuccessStatusCode)
                {
                    var errorString = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    var responseData = await response.Content.ReadAsStringAsync();

                    // var data = JsonConvert.DeserializeObject<IEnumerable<Patient>>(responseData).ToList();
                    var data = JsonConvert.DeserializeObject<PatientResult>(responseData); 

                    return data?.data;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return default;
        }

        [HttpPost]
        public async Task Post([FromBody] Patient patient)
        {
            try
            {
                //var uri = "Patient";
                var uri = "patient/create";
                var content = JsonContent.Create(patient);
                var response = await PatientClient.PostAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorString = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<IEnumerable<Patient>>(responseData).ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }
    }
}
