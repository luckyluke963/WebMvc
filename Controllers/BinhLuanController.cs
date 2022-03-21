using Microsoft.AspNet.Identity;
using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGame.Models.BUS;

namespace WebGame.Controllers
{
    public class BinhLuanController : Controller
    {
        // GET: BinhLuan
        [Authorize]
        public ActionResult Create(BinhLuan bl)
        {
            bl.MaTaiKhoan = User.Identity.GetUserId();
            bl.TinhTrang = 0;
            bl.Ngay = DateTime.Now;
            bl.TenTaiKhoan = User.Identity.Name;
            BinhLuanBUS.ThemBT(bl);
            return RedirectToAction("Details", "ShopGame", new { id = bl.MaSanPham });
        }
    }
}