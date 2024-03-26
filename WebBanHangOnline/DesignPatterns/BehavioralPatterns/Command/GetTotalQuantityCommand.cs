using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.DesignPatterns.BehavioralPatterns.Command
{
    class GetTotalQuantityCommand: ICommand
    {
        // Concrete Command
        private Receiver receiver;
        public GetTotalQuantityCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }
        public void execute()
        {
            receiver.GetTotalQuantity();
        }
    }
}