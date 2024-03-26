using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.DesignPatterns.BehavioralPatterns.Command
{
    class GetTotalPriceCommand: ICommand
    {
        // Concrete Command
        private Receiver receiver;
        public GetTotalPriceCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }
        public void execute()
        {
            receiver.GetTotalPrice();
        }
    }
}