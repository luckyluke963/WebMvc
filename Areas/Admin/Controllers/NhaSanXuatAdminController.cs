using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGame.Models.BUS;

namespace WebGame.Areas.Admin.Controllers
{
    public class NhaSanXuatAdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: Admin/NhaSanXuatAdmin
        public ActionResult Index()
        {
            var ds = NhaSanXuatBus.DanhSachAdmin();
            return View(ds);
        }

        // GET: Admin/NhaSanXuatAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/NhaSanXuatAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhaSanXuatAdmin/Create
        [HttpPost]
        public ActionResult Create(NhaSanXuat nsx)
        {
            try
            {
                // TODO: Add insert logic here
                NhaSanXuatBus.ThemNSX(nsx);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/NhaSanXuatAdmin/Edit/5
        public ActionResult Edit(String id)
        {
            return View(NhaSanXuatBus.ChiTietAdmin(id));
        }

        // POST: Admin/NhaSanXuatAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit( String id, NhaSanXuat nsx)
        {
            try
            {
                // TODO: Add update logic here
                NhaSanXuatBus.UpdateNSX(id, nsx);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult XoaTamThoi(String id)
        {
            return View(NhaSanXuatBus.ChiTietAdmin( id ));
        }
        [HttpPost]
        public ActionResult XoaTamThoi(String id,NhaSanXuat nsx)
        {
            try
            {
                // TODO: Add delete logic here
                nsx.TinhTrang = "1";
                NhaSanXuatBus.UpdateNSX(id, nsx);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Admin/NhaSanXuatAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/NhaSanXuatAdmin/Delete/5
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
