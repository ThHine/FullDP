using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.DesignPatterns.BehavioralPatterns.Iterator
{
    interface Iterator
    {
        ShoppingCartItem First();
        ShoppingCartItem Next();
        bool IsDone { get; }
        ShoppingCartItem CurrentItem { get; }

        void ForEachItem(Action<ShoppingCartItem> func);
    }
}
