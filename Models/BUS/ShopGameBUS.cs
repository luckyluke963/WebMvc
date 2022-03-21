using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebGame.Models.BUS
{
    public class ShopGameBUS
    {
        public static IEnumerable<SanPham> DanhSach()
        {
            var db = new ShopConnectionDB();
            return db.Query<SanPham>("select * from SanPham where TinhTrang ='0         '");
        }
        //truy vấn
        public static SanPham ChiTiet(String a)
        {
            var db = new ShopConnectionDB();
            return db.SingleOrDefault<SanPham> ("select * from SanPham where MaSanPham = @0",a);
        }
        public static IEnumerable<SanPham> TopNew()
        {
            var db = new ShopConnectionDB();
            return db.Query<SanPham>("select Top 4 * from SanPham where LuotView < '100' AND TinhTrang = '0         '");
        }
        public static IEnumerable<SanPham> TopHot()
        {
            var db = new ShopConnectionDB();
            return db.Query<SanPham>("select Top 4 * from SanPham where LuotView > '1000' AND TinhTrang = '0         '");
        }


        public static void CapNhatLuotView(string masp)
        {
            var db = new ShopConnectionDB();
            var a = ChiTiet(masp);
            a.LuotView = a.LuotView + 1;
            db.Update(a, masp);
        }



        //-------------
        public static IEnumerable<SanPham> DanhSachSP()
        {
            var db = new ShopConnectionDB();
            return db.Query<SanPham>("select * from SanPham ");
        }
        public static void InsertSP(SanPham sp)
        {
            var db = new ShopConnectionDB();
            db.Insert(sp);
        }
        public static void UpdateSP(String id,SanPham sp)
        {
            var db = new ShopConnectionDB();
            db.Update(sp, id);
        }



    }
}