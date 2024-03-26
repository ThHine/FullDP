using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Areas.Admin.Controllers;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.DesignPatterns.StructuralPatterns.Proxy
{
    public class ProductProxy : IProxy
    {
        private ProductsController productsController = null;

        public ActionResult Add(Product model, List<string> Images, List<int> rDefault)
        {
            if (productsController == null)
                productsController = new ProductsController();
            return productsController.Add(model, Images, rDefault);
        }

        public ActionResult Delete(int id)
        {
            if (productsController == null)
                productsController = new ProductsController();
            return productsController.Delete(id);
        }

        public ActionResult Edit(Product model)
        {
            if (productsController == null)
                productsController = new ProductsController();
            return productsController.Edit(model);
        }
    }
}