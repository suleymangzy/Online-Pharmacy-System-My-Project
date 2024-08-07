namespace onlinePharmacySystem.Web.Models
{
    public class Products
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public Categories ProductCategory { get; set; }
        public Brands ProductBrand { get; set; }
        public Suppliers ProductSupplier { get; set; }
        public FAQs ProductFAQs { get; set; }
        public string ProductImageURL { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
