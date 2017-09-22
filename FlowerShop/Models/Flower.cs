using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerShop.Models
{
    public class Flower
    {
        public int FlowerID { get; set; }

        public string FlowerName { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
