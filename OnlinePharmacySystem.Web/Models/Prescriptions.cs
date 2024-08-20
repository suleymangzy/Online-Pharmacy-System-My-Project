using onlinePharmacySystem.Web.Models;

namespace OnlinePharmacySystem.Web.Models
{
    public class Prescriptions
    {
        public int PrescriptionID { get; set; }
        public string FileURL { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string DoctorName { get; set; }
        public string HospitalName { get; set; }
        public int UserID { get; set; }
        public Users User { get; set; }
        public int ProductID { get; set; }
        public Products Product { get; set; }
    }
}
