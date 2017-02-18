using OnlineShopping.Domain.Abstract;
using OnlineShopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private readonly EFDbContext context = new EFDbContext();
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }

        public Product DeleteProduct(int productId)
        {
            Product dbEntry = context.Products.Find(productId);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveProduct(Product product)
        {
            if (product.productId == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.Find(product.productId);
                //if (dbEntry != null)
                //{
                //    dbEntry.name = product.name;
                //    dbEntry.description = product.description;
                //    dbEntry.price = product.price;
                //    dbEntry.category = product.category;
                //    dbEntry.ImageData = product.ImageData;
                //    dbEntry.ImageMimeType = product.ImageMimeType;
                //}
                dbEntry.name = product.name;
                dbEntry.description = product.description;
                dbEntry.price = product.price;
                dbEntry.category = product.category;
                if(product.ImageData != null)
                {
                    dbEntry.ImageData = product.ImageData;
                    dbEntry.ImageMimeType = product.ImageMimeType;
                }
            }
            context.SaveChanges();
        }
    }
}
