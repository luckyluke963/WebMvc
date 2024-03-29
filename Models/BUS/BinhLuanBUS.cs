﻿using ShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace WebGame.Models.BUS
{
    public class BinhLuanBUS 
    {
        public static void ThemBT(BinhLuan bl)
        {
            // truy vấn thiếu hoặc sai gì đó
            var db = new ShopConnectionDB();
            //string a = "insert into BinhLuan(MaSanPham,MaTaiKhoan,NoiDung) values('" + MaSanPham + "','" + MaTaiKhoan + "','" + NoiDung + "')";
            db.Insert(bl);
        }
        public static IEnumerable<BinhLuan> LoadBinhLuan(int page = 1, int pagesize = 1)
        {
            var db = new ShopConnectionDB();
            return db.Query<BinhLuan>("select * from BinhLuan ORDER BY Ngay desc").ToPagedList(page, pagesize);
        }
    }
}