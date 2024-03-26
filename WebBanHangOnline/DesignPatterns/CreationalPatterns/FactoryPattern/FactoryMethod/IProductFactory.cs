using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.DesignPatterns.CreationalPatterns.FactoryPattern.FactoryMethod
{
    interface IProductFactory
    {
        Product CreateProduct();
    }
}
