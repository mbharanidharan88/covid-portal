using CovidPortal.Data;
using CovidPortal.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CovidPortal.Business
{
    public class VendorBusiness : IVendorBusiness
    {
        #region Fields

        private readonly IVendorRepository _vendorRepository;

        #endregion

        #region Constructor

        public VendorBusiness(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        #endregion

        #region Public Methods

        public async Task AddVendor(Vendor vendor)
        {
            await _vendorRepository.AddVendor(vendor);
        }

        public async Task<IEnumerable<Vendor>> GetAllVendors()
        {
            return await _vendorRepository.GetAllVendors();
        }

        public async Task<Vendor> GetVendorById(int id)
        {
            return await _vendorRepository.GetVendorById(id);
        }

        #endregion
    }
}
