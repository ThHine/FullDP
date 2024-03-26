using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.DesignPatterns.BehavioralPatterns.Command
{
    class AddToCartCommand : ICommand
    {
        // Concrete Command
        private Receiver receiver;
        private ShoppingCartItem item;
        private int quantity;
        public AddToCartCommand(Receiver receiver, ShoppingCartItem item, int quantity)
        {
            this.receiver = receiver;
            this.item = item;
            this.quantity = quantity;
        }
        public void execute()
        {
            receiver.AddToCart(item, quantity);
        }
    }
}