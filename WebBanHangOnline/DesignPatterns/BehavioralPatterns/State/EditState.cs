using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.DesignPatterns.BehavioralPatterns.State
{
    public class EditState : State
    {
        private ApplicationDbContext db;
        private News model;
        public EditState(News news, ApplicationDbContext db, News model) : base(news)
        {
            this.db = db;
            this.model = model;
        }
        public override void Execute()
        {
            model.ModifiedDate = DateTime.Now;
            model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
            db.News.Attach(model);
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}