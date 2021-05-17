using CovidPortal.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CovidPortal.Data
{
    public interface IVendorRepository
    {
        Task<IEnumerable<Vendor>> GetAllVendors();

        Task<Vendor> GetVendorById(int id);

        Task AddVendor(Vendor vendor);
    }
}
