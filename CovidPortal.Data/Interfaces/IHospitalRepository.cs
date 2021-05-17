using CovidPortal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidPortal.Data
{
    public interface IHospitalRepository
    {
        Task<IEnumerable<Hospital>> GetAllHospitals();

        Task<Hospital> GetHospitalById(int id);

        Task AddHospital(Hospital hospital);
    }
}
