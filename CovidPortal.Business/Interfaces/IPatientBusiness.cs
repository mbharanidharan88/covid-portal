using CovidPortal.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CovidPortal.Business
{
    public interface IPatientBusiness
    {
        Task<IEnumerable<Patient>> GetAllPatients();

        Task<Patient> GetPatientById(int id);

        Task AddPatient(Patient patient);
    }
}
