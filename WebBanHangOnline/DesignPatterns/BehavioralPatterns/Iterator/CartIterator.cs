using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.DesignPatterns.BehavioralPatterns.Iterator
{
    public class CartIterator : Iterator
    {
        List<ShoppingCartItem> listShoppingCartItem;
        int current = 0;
        int step = 1;
        public CartIterator(List<ShoppingCartItem> listShoppingCartItem)
        {
            this.listShoppingCartItem = listShoppingCartItem;
        }
        public bool IsDone
        {
            get { return current >= listShoppingCartItem.Count; }
        } 

        public ShoppingCartItem CurrentItem => listShoppingCartItem[current];

        public ShoppingCartItem First()
        {
            current = 0;
            if(listShoppingCartItem.Count > 0)
                return listShoppingCartItem[current];
            return null;
        }

        public ShoppingCartItem Next()
        {
            current += step;
            if (!IsDone)
                return listShoppingCartItem[current];
            else
                return null;
        }

        public void ForEachItem(Action<ShoppingCartItem> func)
        {
            int i = 0;
            while(i < listShoppingCartItem.Count)
            {
                func(listShoppingCartItem[i++]);
            }
        }
    }
}