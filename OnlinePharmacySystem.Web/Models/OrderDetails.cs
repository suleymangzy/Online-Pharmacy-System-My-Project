namespace onlinePharmacySystem.Web.Models
{
    public class OrderDetails
    {
        public int OrderDetailID { get; set; }
        public Orders OrderDetailOrder { get; set; }
        public Products OrderDetailProduct { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TaxRate { get; set; }
    }
}
