using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.DesignPatterns.BehavioralPatterns.Command;

namespace WebBanHangOnline.Models
{
    class ShoppingCart
    {
        public Invoker invoker { get; set; }
        public Receiver receiver { get; set; }
        public ShoppingCart()
        {
            receiver = new Receiver();
        }

        public void AddToCart(ShoppingCartItem item,int Quantity)
        {
            ICommand addToCart = new AddToCartCommand(receiver, item, Quantity);
            invoker = new Invoker(addToCart);
            invoker.Execute();
        }

        public void Remove(int id)
        {
            ICommand remove = new RemoveCommand(receiver, id);
            invoker = new Invoker(remove);
            invoker.Execute();
        }

        public void UpdateQuantity(int id,int quantity)
        {
            ICommand updateQuantity = new UpdateQuantityCommand(receiver, id, quantity);
            invoker = new Invoker(updateQuantity);
            invoker.Execute();
        }

        public decimal GetTotalPrice()
        {
            return receiver.GetTotalPrice();
        }
        public int GetTotalQuantity()
        {
            return receiver.GetTotalQuantity();
        }
        public void ClearCart()
        {
            ICommand clearCart = new ClearCartCommand(receiver);
            invoker = new Invoker(clearCart);
            invoker.Execute();
        }

    }
}