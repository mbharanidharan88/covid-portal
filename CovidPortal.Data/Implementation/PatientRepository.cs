using CovidPortal.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CovidPortal.Data
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        #region Constructor

        public PatientRepository(PatientDbContext context) : base(context)
        {

        }

        #endregion

        #region Public Methods

        public async Task AddPatient(Patient patient)
        {
            await AddAsync(patient);
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<Patient>> GetAllPatients()
        {
            return await GetAll();
        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await GetById(x => x.Id == id);
        }

        #endregion
    }
}
