
using System;

namespace onlinePharmacySystem.Web.Models
{
    public class Prescriptions
    {
        public int PrescriptionID { get; set; }
        public Users PrescriptionUser { get; set; }
        public string PrescriptionFileURL { get; set; }
        public string PrescriptionStatus { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
