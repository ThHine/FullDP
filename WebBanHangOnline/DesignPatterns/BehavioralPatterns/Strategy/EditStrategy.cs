using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.DesignPatterns.BehavioralPatterns.Strategy
{
    class EditStrategy : IStrategy
    {
        private Product model;
        private ApplicationDbContext db;
        public EditStrategy(Product model, ApplicationDbContext db)
        {
            this.model = model;
            this.db = db;
        }
        public void execute()
        {
            model.ModifiedDate = DateTime.Now;
            model.Alias = Models.Common.Filter.FilterChar(model.Title);
            db.Products.Attach(model);
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}