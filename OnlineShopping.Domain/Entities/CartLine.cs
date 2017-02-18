using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Domain.Entities
{
    public class CartLine
    {
        public Product product { get; set; }
        public int quantity { get; set; }

    }
}
