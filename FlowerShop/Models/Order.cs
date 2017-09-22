using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerShop.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }


        public int FlowerID { get; set; }
        public Flower Flower { get; set; }



    }
}
