using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.DesignPatterns.BehavioralPatterns.Command
{
    class RemoveCommand : ICommand
    {
        // Concrete Command
        private Receiver receiver;
        private int id;
        public RemoveCommand(Receiver receiver, int id)
        {
            this.receiver = receiver;
            this.id = id;
        }
        public void execute()
        {
            receiver.Remove(id);
        }
    }
}