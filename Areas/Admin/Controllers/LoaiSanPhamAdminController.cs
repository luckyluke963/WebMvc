using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGame.Models.BUS;

namespace WebGame.Areas.Admin.Controllers
{
    public class LoaiSanPhamAdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: Admin/LoaiSanPhamAdmin
        public ActionResult Index()
        {
            var db = LoaiSanPhamBus.DanhSachAdmin();
            return View(db); 
        }

        // GET: Admin/LoaiSanPhamAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/LoaiSanPhamAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiSanPhamAdmin/Create
        [HttpPost]
        public ActionResult Create(LoaiSanPham lsp)
        {
            try
            {
                // TODO: Add insert logic here
                LoaiSanPhamBus.InsertLSP(lsp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/LoaiSanPhamAdmin/Edit/5
        public ActionResult Edit(String id )
        {
            var db = LoaiSanPhamBus.ChiTietAdmin(id);
            return View(db);
        }

        // POST: Admin/LoaiSanPhamAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(String id , LoaiSanPham lsp)
        {
            try
            {
                // TODO: Add update logic here
                LoaiSanPhamBus.EditLSP(id, lsp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Admin/LoaiSanPhamAdmin/XoaTamThoi/5
        public ActionResult XoaTamThoi(String id)
        {
            var db = LoaiSanPhamBus.ChiTietAdmin(id);
            return View(db);
           
        }

        // POST: Admin/LoaiSanPhamAdmin/XoaTamThoi/5
        [HttpPost]
        public ActionResult XoaTamThoi(String id, LoaiSanPham lsp)
        {
            try
            {
                // TODO: Add delete logic here
                lsp.TinhTrang = "1";
                LoaiSanPhamBus.EditLSP(id, lsp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/LoaiSanPhamAdmin/Delete/5
        public ActionResult Xoa(int id)
        {
            return View();
        }

        // POST: Admin/LoaiSanPhamAdmin/Delete/5
        [HttpPost]
        public ActionResult Xoa(int id, FormCollection collection)
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
