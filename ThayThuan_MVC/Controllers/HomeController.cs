using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThayThuan_MVC.Controllers
{
    public class HomeController : Controller
    {
        private ThayThuanMVCEntities db = new ThayThuanMVCEntities();
        public ActionResult Index()
        {
            var sanmphamnew = db.Database.SqlQuery<SanPham>("SELECT TOP (10) * FROM [ThayThuanMVC].[dbo].[SanPham] ORDER BY ID DESC").ToList();
            if (ViewData["nguoidung"] != null)
            {
                ViewData["IndexNguoiDung"] = (NguoiDung)ViewData["nguoidung"];
            }
            else
            {
                ViewData["IndexNguoiDung"] = null;
            }
            return View(sanmphamnew);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                id = 1;
            }
            SanPham danhsachsanpham = db.SanPham.Find(id);
            if (danhsachsanpham == null)
            {
                return HttpNotFound();
            }
            return View(danhsachsanpham);
        }

        public ActionResult Post()
        {
            return View();
        }

        public ActionResult Shop()
        {
            return View();
        }

        public ActionResult ShopCart()
        {
            string user = HttpContext.Request.Form["user"];
            string password = HttpContext.Request.Form["password"];
            NguoiDung nguoidung = db.NguoiDung.FirstOrDefault(x => x.UserName == user && x.Password == password);
            return View(nguoidung);
        }
        public ActionResult Submit()
        {
            string user = HttpContext.Request.Form["user"];
            string password = HttpContext.Request.Form["password"];
            NguoiDung nguoidung = db.NguoiDung.FirstOrDefault(x => x.UserName == user && x.Password == password);
            if (nguoidung != null)
            {
                ViewData["NguoiDung"] = nguoidung;
            }
            else
            {
                ViewData["NguoiDung"] = null;
            }
            return RedirectToAction("Index");
        }
    }
}