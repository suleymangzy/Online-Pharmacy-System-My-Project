using System;

namespace onlinePharmacySystem.Web.Models
{
    public class Prescriptions
    {
        public int PrescriptionID { get; set; }
        public int PrescriptionUserID { get; set; }  // Yabancı anahtar
        public Users PrescriptionUser { get; set; }
        public string PrescriptionFileURL { get; set; }
        public string PrescriptionStatus { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
