using CovidPortal.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CovidPortal.Data
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllPatients();

        Task<Patient> GetPatientById(int id);

        Task AddPatient(Patient patient);
    }
}
