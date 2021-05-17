using CovidPortal.Data;
using CovidPortal.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CovidPortal.Business
{
    public class HospitalBusiness : IHospitalBusiness
    {
        #region Fields

        private readonly IHospitalRepository _hospitalRepository;

        #endregion

        #region Constructor

        public HospitalBusiness(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }


        #endregion

        #region Public Methods

        #endregion
        public async Task AddHospital(Hospital hospital)
        {
            await _hospitalRepository.AddHospital(hospital);
        }

        public async Task<IEnumerable<Hospital>> GetAllHospitals()
        {
            return await _hospitalRepository.GetAllHospitals();
        }


        public async Task<Hospital> GetHospitalById(int id)
        {
            return await _hospitalRepository.GetHospitalById(id);
        }
    }
}
