using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection.Where(p => p.product.productId == product.productId).FirstOrDefault();
            if(line == null)
            {
                lineCollection.Add(new CartLine { product = product, quantity = quantity });
            }
            else
            {
                line.quantity += quantity;
            }
        }
        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(p => p.product.productId == product.productId);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(p => p.product.price * p.quantity);
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

        public void Clear()
        {
            lineCollection.Clear();
        }
    }
}
