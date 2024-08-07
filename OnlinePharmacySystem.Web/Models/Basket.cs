using Microsoft.VisualBasic;
using System.Collections.Generic;
using System;

namespace onlinePharmacySystem.Web.Models
{
    public class Basket
    {
        public int BasketID { get; set; }
        public ICollection<OrderDetails> BasketOrderDetails { get; set; }
        public Users BasketUser { get; set; }
        public DateTime BasketDate { get; set; }
    }
}
