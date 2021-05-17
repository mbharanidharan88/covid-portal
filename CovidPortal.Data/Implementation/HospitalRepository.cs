using CovidPortal.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CovidPortal.Data
{
    public class HospitalRepository : BaseRepository<Hospital>, IHospitalRepository
    {
        #region Constructor

        public HospitalRepository(HospitalDbContext context) : base(context)
        {

        }

        #endregion

        #region Public Methods

        public async Task AddHospital(Hospital hospital)
        {
            await AddAsync(hospital);
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<Hospital>> GetAllHospitals()
        {
            return await GetAll();
        }

        public async Task<Hospital> GetHospitalById(int id)
        {
            return await GetById(x => x.Id == id);
        }

        #endregion
    }
}
