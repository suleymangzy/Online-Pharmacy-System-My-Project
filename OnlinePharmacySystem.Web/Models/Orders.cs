using Microsoft.VisualBasic;
using System.Collections.Generic;
using System;

namespace onlinePharmacySystem.Web.Models
{
    public class Orders
    {
        public int OrderID { get; set; }
        public Users OrderUser { get; set; }
        public Payments OrderPayment { get; set; }
        public Pharmacies OrderPharmacy { get; set; }
        public ICollection<Products> OrderProducts { get; set; }
        public string OrderInvoiceNo { get; set; }
        public DateTime OrderCreatedAt { get; set; }
        public Deliveries OrderDelivery { get; set; }
    }
}
