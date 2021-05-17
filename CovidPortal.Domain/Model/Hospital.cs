using CovidPortal.Domain.Identity;

namespace CovidPortal.Domain.Model
{
    public class Hospital : BaseEntity
    {
        public string HospitalName { get; set; }

        public string HospitalCity { get; set; }

        public int NumberOfBeds { get; set; }

        public float OxygenCapacityInTonnes { get; set; }

        public float BalanceCapacityInTonnes { get; set; }

        public string ApplicationUserId { get; set; }

        //public virtual ApplicationUser User { get; set; }
    }
}
