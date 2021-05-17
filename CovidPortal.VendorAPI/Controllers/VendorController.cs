using CovidPortal.Business;
using CovidPortal.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CovidPortal.VendorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendorController : ControllerBase
    {
        #region Fields

        private readonly IVendorBusiness _vendorBusiness;
        private readonly ILogger<VendorController> _logger;


        #endregion

        #region Constructor

        public VendorController(IVendorBusiness vendorBusiness,
            ILogger<VendorController> logger)
        {
            _vendorBusiness = vendorBusiness;
            _logger = logger;
        }

        #endregion

        #region API Methods

        [HttpGet]
        public async Task<IEnumerable<Vendor>> Get()
        {
            return await _vendorBusiness.GetAllVendors();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Vendor> Get([FromRoute] int id)
        {
            return await _vendorBusiness.GetVendorById(id);
        }

        [HttpPost]
        public async Task Post([FromBody] Vendor vendor)
        {
            await _vendorBusiness.AddVendor(vendor);
        }

        #endregion
    }
}
