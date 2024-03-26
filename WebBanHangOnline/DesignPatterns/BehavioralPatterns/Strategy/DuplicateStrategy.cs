using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.DesignPatterns.BehavioralPatterns.Strategy
{
    class DuplicateStrategy : IStrategy
    {
        private Product model;
        private ApplicationDbContext db;
        private int id;
        private Product product;
        public DuplicateStrategy(Product model, ApplicationDbContext db, int id, Product product)
        {
            this.model = model;
            this.db = db;
            this.id = id;
            this.product = product; 
        }
        public void execute()
        {
            var productImages = db.ProductImages
                               .Where(p => p.ProductId == id)
                               .ToList();

            model = (Product)product.Clone();
            db.Products.Add(model);
            db.SaveChanges();

            foreach (var productImage in productImages)
            {
                db.ProductImages.Add(new ProductImage() { ProductId = model.Id, Image = productImage.Image, IsDefault = productImage.IsDefault });
            }
            db.SaveChanges();
        }
    }
}