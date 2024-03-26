using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.DesignPatterns.StructuralPatterns.Proxy
{
    interface IProxy
    {
        ActionResult Add(Product model, List<string> Images, List<int> rDefault);
        ActionResult Edit(Product model);
        ActionResult Delete(int id);
    }
}
