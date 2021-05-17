using CovidPortal.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidPortal.UI.Models
{
    public class PatientResult
    {
        public string _id { get; set; }
        public bool hasData { get; set; }
        public List<Patient> data { get; set; }
        public string id { get; set; }

    }
}
