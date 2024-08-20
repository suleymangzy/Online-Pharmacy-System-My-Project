using System;

namespace onlinePharmacySystem.Web.Models
{
    public class OrderDetails
    {
        public int OrderDetailID { get; set; }

        // Foreign Key
        public int OrderID { get; set; }
        public Orders OrderDetailOrder { get; set; } // İlişkiyi temsil eden navigasyon özelliği

        public int ProductID { get; set; } // Yabancı anahtar
        public Products OrderDetailProduct { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TaxRate { get; set; }
    }
}

