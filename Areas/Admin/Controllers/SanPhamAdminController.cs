using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGame.Models.BUS;

namespace WebGame.Areas.Admin.Controllers
{
    public class SanPhamAdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: Admin/SanPhamAdmin
        public ActionResult Index()
        {
            
            return View(ShopGameBUS.DanhSachSP());
        }

        // GET: Admin/SanPhamAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/SanPhamAdmin/Create
        public ActionResult Create()
        {
            ViewBag.MaNhaSanXuat = new SelectList(NhaSanXuatBus.DanhSach(), "MaNhaSanXuat", "TenNhaSanXuat");
            ViewBag.MaLoaiSanPham = new SelectList(LoaiSanPhamBus.DanhSach(), "MaLoaiSanPham", "TenLoaiSanPham");
            return View();
        }

        // POST: Admin/SanPhamAdmin/Create
        [HttpPost] 
        [ValidateInput(false)]
        public ActionResult Create(SanPham sp)
        {
           
            try
            {
                var hpf = HttpContext.Request.Files[0];
                if(hpf.ContentLength > 0)
                {
                    string fileName = sp.MaSanPham;

                    String fullPathWithFileName = "~/Asset/img/" + fileName + ".png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.HinhChinh = sp.MaSanPham + ".png";
                }
                
                 hpf = HttpContext.Request.Files[1];
                if (hpf.ContentLength > 0)
                { 
                    string fileName = sp.MaSanPham;

                    String fullPathWithFileName = "~/Asset/img/" + fileName + "_1.png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.Hinh1= sp.MaSanPham + "_1.png";
                }

                 hpf = HttpContext.Request.Files[2];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.MaSanPham;

                    String fullPathWithFileName = "~/Asset/img/" + fileName + "_2.png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.Hinh2 = sp.MaSanPham + "_2.png";
                }
                 hpf = HttpContext.Request.Files[3];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.MaSanPham;

                    String fullPathWithFileName = "~/Asset/img/" + fileName + "_3.png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.Hinh3 = sp.TenSanPham + "_3.png";
                }
                 hpf = HttpContext.Request.Files[4];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.Hinh4;

                    String fullPathWithFileName = "~/Asset/img/" + fileName + "_4.png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.Hinh4 = sp.TenSanPham + "_4.png";
                }
                
                sp.TinhTrang = "0";
                sp.SoLuongDaBan = 0;
                sp.LuotView = 0;
             
                // TODO: Add insert logic here
                ShopGameBUS.InsertSP(sp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/SanPhamAdmin/Edit/5
        public ActionResult Edit(String  id)
        {
            ViewBag.MaNhaSanXuat = new SelectList(NhaSanXuatBus.DanhSach(), "MaNhaSanXuat", "TenNhaSanXuat",ShopGameBUS.ChiTiet(id).MaNhaSanXuat);
            ViewBag.MaLoaiSanPham = new SelectList(LoaiSanPhamBus.DanhSach(), "MaLoaiSanPham", "TenLoaiSanPham",ShopGameBUS.ChiTiet(id).MaLoaiSanPham);
            return View(ShopGameBUS.ChiTiet(id));
        }

        // POST: Admin/SanPhamAdmin/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(String id, SanPham sp)
        {
            var tam = ShopGameBUS.ChiTiet(id);
            try
            {
                // TODO: Add update logic here
                var hpf = HttpContext.Request.Files[0];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.MaSanPham;

                    String fullPathWithFileName = "~/Asset/img/" + fileName + ".png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.HinhChinh = sp.MaSanPham + ".png";
                }
                else
                {
                    sp.HinhChinh = tam.HinhChinh;
                }
                hpf = HttpContext.Request.Files[1];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.MaSanPham;

                    String fullPathWithFileName = "~/Asset/img/" + fileName + "_1.png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.Hinh1 = sp.MaSanPham + "_1.png";
                }
                else
                {
                    sp.Hinh1 = tam.Hinh1;
                }
                hpf = HttpContext.Request.Files[2];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.MaSanPham;

                    String fullPathWithFileName = "~/Asset/img/" + fileName + "_2.png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.Hinh2 = sp.MaSanPham + "_2.png";
                }
                else
                {
                    sp.Hinh2 = tam.Hinh2;
                }
                hpf = HttpContext.Request.Files[3];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.MaSanPham;

                    String fullPathWithFileName = "~/Asset/img/" + fileName + "_3.png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.Hinh3 = sp.MaSanPham + "_3.png";
                }
                else
                {
                    sp.Hinh3 = tam.Hinh3;
                }
                hpf = HttpContext.Request.Files[4];
                if (hpf.ContentLength > 0)
                {
                    string fileName = sp.MaSanPham;

                    String fullPathWithFileName = "~/Asset/img/" + fileName + "_4.png";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.Hinh4 = sp.MaSanPham + "_4.png";
                }
                else
                {
                    sp.Hinh4 = tam.Hinh4;
                }
                if (sp.SoLuongDaBan > 10000)
                {
                    sp.SoLuongDaBan = 0;
                }
                else
                {
                    sp.SoLuongDaBan = tam.SoLuongDaBan;
                }
                if(sp.LuotView > 10000) {
                    sp.LuotView = 0; 
                }
                else
                {
                    sp.LuotView = tam.LuotView;
                }
                sp.TinhTrang = tam.TinhTrang;
                ShopGameBUS.UpdateSP(id, sp);
                // TODO: Add insert logic here
            
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/SanPhamAdmin/Delete/5
        public ActionResult Delete(String  id)
        {

            return View(ShopGameBUS.ChiTiet(id));
        }

        // POST: Admin/SanPhamAdmin/Delete/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Delete(String id,SanPham sp)
        {
            var tam = ShopGameBUS.ChiTiet(id);
            try
            {
                // TODO: Add delete logic here
                
                 if(tam.SoLuongDaBan > 10000)
                {
                    tam.SoLuongDaBan = 0;
                }
                
                if(tam.LuotView > 10000) { tam.LuotView = 0; } 
                if(tam.TinhTrang  == "1         ") { tam.TinhTrang = "0         "; }
                else
                {
                    tam.TinhTrang = "1         ";
                }
              
               
                ShopGameBUS.UpdateSP(id, tam);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
