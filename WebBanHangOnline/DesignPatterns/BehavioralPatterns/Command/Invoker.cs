using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.DesignPatterns.BehavioralPatterns.Command
{
    class Invoker
    {
        // Invoker
        private ICommand icommand;
        public Invoker(ICommand icommand)
        {
            this.icommand = icommand;
        }
        public void Execute()
        {
            icommand.execute();
        }
    }
}