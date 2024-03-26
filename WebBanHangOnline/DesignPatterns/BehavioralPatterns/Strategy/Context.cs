using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.DesignPatterns.BehavioralPatterns.Strategy
{
    class Context
    {
        private IStrategy istrategy;
        public Context(IStrategy istrategy)
        {
            this.istrategy = istrategy;
        }
        public void Execute()
        {
            istrategy.execute();
        }
    }
}