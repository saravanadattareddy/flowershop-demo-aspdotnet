using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerShop.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime RegistrationDate { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
