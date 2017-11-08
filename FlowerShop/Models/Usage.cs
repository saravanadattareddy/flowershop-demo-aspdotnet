using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerShop.Models
{
    public class Usage
    {
        public int UsageId { get; set; }

        public int OccasionId { get; set; }

        public Occasion Occassion { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
