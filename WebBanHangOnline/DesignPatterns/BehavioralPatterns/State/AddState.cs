using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.DesignPatterns.BehavioralPatterns.State
{
    public class AddState : State
    {
        private ApplicationDbContext db;
        private News model;
        public AddState(News news, ApplicationDbContext db, News model) : base(news)
        {
            this.db = db;
            this.model = model;
        }
        public override void Execute()
        {
            model.CreatedDate = DateTime.Now;
            model.CategoryId = 3;
            model.ModifiedDate = DateTime.Now;
            model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
            db.News.Add(model);
            db.SaveChanges();
        }
    }
}