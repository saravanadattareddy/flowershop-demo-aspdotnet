using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerShop.Models
{
    public class OrderLn
    {
        public int OrderLnId { get; set; }
        public int Number { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }


        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
}
