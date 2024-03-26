using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.DesignPatterns.BehavioralPatterns.State
{
    public abstract class State
    {
        protected News news;
        public State(News news)
        {
            this.news = news;
        }
        public abstract void Execute();
    }
}