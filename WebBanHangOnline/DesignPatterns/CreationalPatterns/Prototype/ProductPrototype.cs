using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBanHangOnline.DesignPatterns.CreationalPatterns.Prototype
{
    public interface ProductPrototype
    {
        ProductPrototype Clone();
    }
}
