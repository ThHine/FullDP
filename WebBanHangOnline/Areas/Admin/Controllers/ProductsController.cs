﻿using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.DesignPatterns.BehavioralPatterns.Strategy;
using WebBanHangOnline.DesignPatterns.CreationalPatterns.FactoryPattern.FactoryMethod;
using WebBanHangOnline.DesignPatterns.FactoryPattern.FactoryMethod;
using WebBanHangOnline.DesignPatterns.StructuralPatterns.Proxy;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class ProductsController : Controller, IProxy
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private Context context;

        // GET: Admin/Products
        public ActionResult Index(int? page)
        {
            IEnumerable<Product> items = db.Products.OrderByDescending(x => x.Id);
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }

        public ActionResult Add()
        {
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "Id", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Product model, List<string> Images, List<int> rDefault)
        {
            if (ModelState.IsValid)
            {
                if (Images != null && Images.Count > 0)
                {
                    for (int i = 0; i < Images.Count; i++)
                    {
                        if (i + 1 == rDefault[0])
                        {
                            model.Image = Images[i];
                            model.ProductImage.Add(new ProductImage
                            {
                                ProductId = model.Id,
                                Image = Images[i],
                                IsDefault = true
                            });
                        }
                        else
                        {
                            model.ProductImage.Add(new ProductImage
                            {
                                ProductId = model.Id,
                                Image = Images[i],
                                IsDefault = false
                            });
                        }
                    }
                }
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                if (string.IsNullOrEmpty(model.SeoTitle))
                {
                    model.SeoTitle = model.Title;
                }
                if (string.IsNullOrEmpty(model.Alias))
                    model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                db.Products.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "Id", "Title");
            return View(model);
        }

        public ActionResult AddProxy(Product model, List<string> Images, List<int> rDefault)
        {
            IProxy iProxy = new ProductProxy();
            return iProxy.Add(model, Images, rDefault);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "Id", "Title");
            var item = db.Products.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product model)
        {
            IStrategy editStrategy = new EditStrategy(model, db);
            context = new Context(editStrategy);
            if (ModelState.IsValid)
            {
                context.Execute();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult EditProxy(Product model)
        {
            IProxy iProxy = new ProductProxy();
            return iProxy.Edit(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            IStrategy removeStrategy = new RemoveStrategy(id, db, product);
            context = new Context(removeStrategy);

            if (product != null)
            {
                context.Execute();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        public ActionResult DeleteProxy(int id)
        {
            IProxy iProxy = new ProductProxy();
            return iProxy.Delete(id);
        }

        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isAcive = item.IsActive });
            }

            return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult IsHome(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                item.IsHome = !item.IsHome;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, IsHome = item.IsHome });
            }

            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IsSale(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                item.IsSale = !item.IsSale;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, IsSale = item.IsSale });
            }

            return Json(new { success = false });
        }

        public ActionResult Duplicate(int id)
        {
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "Id", "Title");
            var item = db.Products.Find(id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Duplicate(Product model, int id)
        {
            Product product = db.Products.Find(id);
            IStrategy duplicateStrategy = new DuplicateStrategy(model, db, id, product);
            context = new Context(duplicateStrategy);

            if (product != null)
            {
                context.Execute();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult RandomProduct()
        {
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "Id", "Title");
            return View();
        }
        [HttpPost]
        public ActionResult RandomProduct(Product model)
        {
            IProductFactory pFactory = new RandomFactory(model, db);
            Product p = pFactory.CreateProduct();
            if(p != null)
                return RedirectToAction("Index");
            return View(model);
        }
    }
}