
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WebGame.Models.BUS;

namespace WebGame.Controllers
{
    public class ShopGameController : Controller
    {
        // GET: ShopGame
        public ActionResult Index(int page = 1,int pagesize =8) // số sản phẩm hiện lên
        {
            var db = ShopGameBUS.DanhSach().ToPagedList(page,pagesize); 
            return View(db);
        }

        // GET: ShopGame/Details/5
        public ActionResult Details(String id, int page = 1, int pagesize = 3)
        {
            ShopGameBUS.CapNhatLuotView(id);
            var db = ShopGameBUS.ChiTiet(id);
            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
            return View(db);
        }

        // GET: ShopGame/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShopGame/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopGame/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShopGame/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopGame/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShopGame/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
