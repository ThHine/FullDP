using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.DesignPatterns.BehavioralPatterns.Command
{
    class UpdateQuantityCommand: ICommand
    {
        // Concrete Command
        private Receiver receiver;
        private int id;
        private int quantity;
        public UpdateQuantityCommand(Receiver receiver, int id, int quantity)
        {
            this.receiver = receiver;
            this.id = id;
            this.quantity = quantity;
        }
        public void execute()
        {
            receiver.UpdateQuantity(id, quantity);
        }
    }
}