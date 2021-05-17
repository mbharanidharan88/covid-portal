using CovidPortal.Data;
using CovidPortal.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CovidPortal.Business
{
    public class PatientBusiness : IPatientBusiness
    {
        #region Fields

        private readonly IPatientRepository _patientRepository;

        #endregion

        #region Constructor

        public PatientBusiness(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        #endregion

        #region Public Methods

        public async Task AddPatient(Patient patient)
        {
            await _patientRepository.AddPatient(patient);
        }

        public async Task<IEnumerable<Patient>> GetAllPatients()
        {
            return await _patientRepository.GetAllPatients();
        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await _patientRepository.GetPatientById(id);
        }

        #endregion
    }
}
