using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.DesignPatterns.BehavioralPatterns.State
{
    public class RemoteState : State
    {
        private ApplicationDbContext db;
        private News item;
        public RemoteState(News news, ApplicationDbContext db, News item) : base(news)
        {
            this.db = db;
            this.item = item;
        }
        public override void Execute()
        {
            db.News.Remove(item);
            db.SaveChanges();
        }
    }
}