using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using WebBanHangOnline.Models.EF;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.DesignPatterns.Singleton
{
    public sealed class Singleton
    {
        public static Singleton Instance { get; } = new Singleton();
        public List<Category> listCategory { get; } = new List<Category>();
        private Singleton() { }

        // only one time
        public void Init(ApplicationDbContext db)
        {
            if(listCategory.Count == 0)
            {
                var categories = db.Categories;
                foreach(var item in categories)
                {
                    listCategory.Add(item);
                }
            }
        }
        public void Update(ApplicationDbContext db)
        {
            listCategory.Clear();
            Init(db);
        }
    }
}