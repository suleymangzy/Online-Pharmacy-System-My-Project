using System;
using System.Collections.Generic;

namespace onlinePharmacySystem.Web.Models
{
    public class Orders
    {
        public int OrderID { get; set; }
        public int OrderUserID { get; set; }  
        public Users OrderUser { get; set; }
        public int OrderPaymentID { get; set; }  
        public Payments OrderPayment { get; set; }
        public int OrderPharmacyID { get; set; }  
        public Pharmacies OrderPharmacy { get; set; }
        public string OrderInvoiceNo { get; set; }
        public DateTime OrderCreatedAt { get; set; }
        public int OrderDeliveryID { get; set; }  
        public Deliveries OrderDelivery { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
