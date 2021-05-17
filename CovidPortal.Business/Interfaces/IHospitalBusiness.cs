using CovidPortal.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CovidPortal.Business
{
    public interface IHospitalBusiness
    {
        Task<IEnumerable<Hospital>> GetAllHospitals();

        Task<Hospital> GetHospitalById(int id);

        Task AddHospital(Hospital hospital);
    }
}
