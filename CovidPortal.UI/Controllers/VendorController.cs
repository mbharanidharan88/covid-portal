using CovidPortal.Domain.Model;
using Microsoft.AspNetCore.Http;
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
    public class VendorController : BaseController
    {
        private readonly ILogger<VendorController> _logger;

        public VendorController(ILogger<VendorController> logger,
                                    IConfiguration configuration) : base(configuration)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Vendor>> Get()
        {
            try
            {
                var uri = "Vendor";
                var response = await VendorClient.GetAsync(uri);

                if (!response.IsSuccessStatusCode)
                {
                    var errorString = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    var responseData = await response.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<IEnumerable<Vendor>>(responseData).ToList();

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
        public async Task Post([FromBody] Vendor vendor)
        {
            try
            {
                var uri = "Vendor";
                var content = JsonContent.Create(vendor);
                var response = await VendorClient.PostAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorString = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<IEnumerable<Vendor>>(responseData).ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }
    }
}
