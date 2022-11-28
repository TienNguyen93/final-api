using System;
namespace CustomerAPI.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string OrderDate { get; set; }
        public string ShipDate { get; set; }
        public bool IsShipped { get; set; }

    }
}
