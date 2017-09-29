using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerShop.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Customer_Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
  
        public ICollection<Order> Orders { get; set; }
    }
}
