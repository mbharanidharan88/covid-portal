using CovidPortal.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CovidPortal.Data
{
    public class VendorRepository : BaseRepository<Vendor>, IVendorRepository
    {
        #region Constructor

        public VendorRepository(VendorDbContext context) : base(context)
        {

        }

        #endregion

        #region Public Methods

        public async Task AddVendor(Vendor vendor)
        {
            await AddAsync(vendor);
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<Vendor>> GetAllVendors()
        {
            return await GetAll();
        }

        public async Task<Vendor> GetVendorById(int id)
        {
            return await GetById(x => x.Id == id);
        }

        #endregion
    }
}
