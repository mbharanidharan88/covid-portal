using CovidPortal.Domain.Model;
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
    public class HospitalController : BaseController
    {

        private readonly ILogger<HospitalController> _logger;

        public HospitalController(ILogger<HospitalController> logger, 
                                    IConfiguration configuration) : base(configuration)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Hospital>> Get()
        {
            try
            {
                var uri = "Hospital";
                var response = await HospitalClient.GetAsync(uri);

                if (!response.IsSuccessStatusCode)
                {
                    var errorString = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    var responseData = await response.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<IEnumerable<Hospital>>(responseData).ToList();

                    return data;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return default;
        }

        [HttpPost]
        public async Task Post([FromBody] Hospital hospital)
        {
            try
            {
                var uri = "Hospital";
                var content = JsonContent.Create(hospital);
                var response = await HospitalClient.PostAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorString = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<IEnumerable<Hospital>>(responseData).ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }
    }
}
