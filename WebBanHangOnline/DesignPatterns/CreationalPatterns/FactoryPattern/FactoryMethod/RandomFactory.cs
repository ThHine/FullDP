using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.DesignPatterns.CreationalPatterns.FactoryPattern.FactoryMethod;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.DesignPatterns.FactoryPattern.FactoryMethod
{
    class RandomFactory : IProductFactory
    {
        private ApplicationDbContext db;
        private Product product;
        public RandomFactory(Product product, ApplicationDbContext db)
        {
            this.db = db;
            this.product = product;
        }
        public Product CreateProduct()
        {
            Random r = new Random();
            int randomId = r.Next(6, 18);
            var item = db.Products.Find(randomId);
            var productImages = db.ProductImages
                                .Where(p => p.ProductId == randomId)
                                .ToList();
            if (item != null)
            {
                product = (Product)item.Clone();
                db.Products.Add(product);
                db.SaveChanges();

                foreach (var productImage in productImages)
                {
                    db.ProductImages.Add(new ProductImage() { ProductId = product.Id, Image = productImage.Image, IsDefault = productImage.IsDefault });
                }
                db.SaveChanges();
            }
            return product;
        }
    }
}