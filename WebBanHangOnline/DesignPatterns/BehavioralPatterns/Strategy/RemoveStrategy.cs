using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.DesignPatterns.BehavioralPatterns.Strategy
{
    class RemoveStrategy : IStrategy
    {
        private int id;
        private ApplicationDbContext db;
        private Product product;

        public RemoveStrategy(int id, ApplicationDbContext db, Product product)
        {
            this.id = id;
            this.db = db;
            this.product = product;
        }
        public void execute()
        {
            var checkImg = product.ProductImage.Where(x => x.ProductId == product.Id);
            if (checkImg != null)
            {
                foreach (var img in checkImg)
                {
                    db.ProductImages.Remove(img);
                    db.SaveChanges();
                }
            }
            db.Products.Remove(product);
            db.SaveChanges();
        }
    }
}