using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
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
            int IDuser = -1;
            if (Request.Cookies["user"] != null)
            {
                try
                {
                    IDuser = int.Parse(Request.Cookies["user"].Value);
                }
                catch
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
            var listCart = db.GioHang.Where(x => x.IDNguoiDung == IDuser).ToList();
            return View(listCart);
        }
        [HttpPost]
        public ActionResult Submit(string username, string password)
        {
            NguoiDung nguoidung = db.NguoiDung.FirstOrDefault(x => x.UserName == username && x.Password == password);
            if (nguoidung != null)
            {
                var ID = nguoidung.ID;
                var Name = nguoidung.HoTen;

                // Trả về JsonResult chứa hai giá trị
                return Json(new { ID = ID, Name = Name });
            }
            else
            {
                return Content("Đăng nhập không thành công");
            }
        }

        [HttpPost]
        public ActionResult GetUser(int IdUser)
        {
            NguoiDung nguoidung = db.NguoiDung.FirstOrDefault(x => x.ID == IdUser);
            if (nguoidung != null)
            {
                var ID = nguoidung.ID;
                var Name = nguoidung.HoTen;

                // Trả về JsonResult chứa hai giá trị
                return Json(new { ID = ID, Name = Name });
            }
            else
            {
                return Content("Đăng nhập không thành công");
            }
        }
        [HttpPost]
        public ActionResult AddCart(int IDUser, int ID, int Quanity)
        {
            GioHang gioHag = db.GioHang.Where(x => x.IDNguoiDung == IDUser && x.IDSanPham == ID).FirstOrDefault();
            if (gioHag != null)
            {
                var QuantityFind = gioHag.SoLuong + Quanity;
                var QuantitySum = db.SanPham.Find(ID).SoLuong;
                if (QuantityFind < QuantitySum)
                {
                    gioHag.SoLuong = QuantityFind;
                }
                else
                {
                    gioHag.SoLuong = QuantitySum;
                }
            }
            else
            {
                GioHang gioHang = new GioHang();
                gioHang.IDNguoiDung = IDUser;
                gioHang.IDSanPham = ID;
                gioHang.SoLuong = Quanity;
                db.GioHang.Add(gioHang);
            }
            db.SaveChanges();
            return Json(new { IDUser = IDUser, ID = ID, Name = Quanity });
        }
        [HttpPost]
        public ActionResult DeleteProduct(string ID)
        {
            int IDCheck = int.Parse(ID);
            GioHang gioHang = db.GioHang.Find(IDCheck);
            db.GioHang.Remove(gioHang);
            db.SaveChanges();
            return RedirectToAction("ShopCart");
        }

        [HttpPost]
        public ActionResult SignUp(string username, string password, string email)
        {
            bool isAlreadyExisted = db.NguoiDung.Where(user => user.UserName.Equals(username)).FirstOrDefault() != null;
            if (isAlreadyExisted)
                return Json(new { success = false, message = "Tài khoản đã tồn tại" });

            db.Database.ExecuteSqlCommand("INSERT INTO [dbo].[NguoiDung] ([UserName], [Password] ,[IDQuyen], [HoTen], [SoDienThoai], [Email]) VALUES (@p0, @p1, 2, @p0, NULL, @p2)", username, password, email);

            return Json(new { success = true, message = "Đăng ký thành công rồi nha." });

        }
        [HttpPost]
        public ActionResult tangGiamSanPham(string ID, int k, int SoLuong)
        {
            int IDCheck = int.Parse(ID);
            GioHang gioHang = db.GioHang.Find(IDCheck);
            gioHang.SoLuong += k;
            if (gioHang.SoLuong.Value > SoLuong)
            {
                gioHang.SoLuong = SoLuong;
            }
            if (gioHang.SoLuong.Value <= 0)
            {
                gioHang.SoLuong = 0;
            }
            db.SaveChanges();
            return RedirectToAction("ShopCart");
        }
        [HttpPost]
        public ActionResult getSizeCart(string IdUser)
        {
            int ID = int.Parse(IdUser);
            var listCart = db.GioHang.Where(x => x.IDNguoiDung == ID).ToList();
            int Size = listCart.Count();
            return Json(new { Size = Size });
        }

    }
}