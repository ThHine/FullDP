using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.DesignPatterns.BehavioralPatterns.Command
{
    class ClearCartCommand: ICommand
    {
        // Concrete Command
        private Receiver receiver;
        public ClearCartCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }
        public void execute()
        {
            receiver.ClearCart();
        }
    }
}