using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.DesignPatterns.BehavioralPatterns.Command
{
    class Receiver
    {
        public List<ShoppingCartItem> Items { get; set; }
        public Receiver()
        {
            Items = new List<ShoppingCartItem>();
        }
        public void AddToCart(ShoppingCartItem item, int Quantity)
        {
            var checkExits = Items.FirstOrDefault(x => x.ProductId == item.ProductId);
            if (checkExits != null)
            {
                checkExits.Quantity += Quantity;
                checkExits.TotalPrice = checkExits.Price * checkExits.Quantity;
            }
            else
            {
                Items.Add(item);
            }
        }
        public void Remove(int id)
        {
            var checkExits = Items.SingleOrDefault(x => x.ProductId == id);
            if (checkExits != null)
            {
                Items.Remove(checkExits);
            }
        }

        public void UpdateQuantity(int id, int quantity)
        {
            var checkExits = Items.SingleOrDefault(x => x.ProductId == id);
            if (checkExits != null)
            {
                checkExits.Quantity = quantity;
                checkExits.TotalPrice = checkExits.Price * checkExits.Quantity;
            }
        }
        public decimal GetTotalPrice()
        {
            return Items.Sum(x => x.TotalPrice);
        }
        public int GetTotalQuantity()
        {
            return Items.Sum(x => x.Quantity);
        }
        public void ClearCart()
        {
            Items.Clear();
        }

    }
}