using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThayThuan_MVC;

namespace ThayThuan_MVC.Areas.Shoper.Controllers
{
    public class SanPhamsController : Controller
    {
        private ThayThuanMVCEntities db = new ThayThuanMVCEntities();

        // GET: Shoper/SanPhams
        public ActionResult Index(int? IDDoiTuong, int? IDTheLoai)
        {
            var sanPham = db.SanPham.Include(s => s.DoiTuong).Include(s => s.TheLoai).ToList();
            if (IDDoiTuong != null && IDDoiTuong != 0 && IDTheLoai != null && IDTheLoai != 0)
            {
                sanPham = db.SanPham.Include(s => s.DoiTuong).Include(s => s.TheLoai).Where(x => x.IDDoiTuong == IDDoiTuong).Where(x => x.IDTheLoai == IDTheLoai).ToList();
            }

            if (IDDoiTuong != null && IDDoiTuong != 0 && (IDTheLoai == null || IDTheLoai == 0))
            {
                sanPham = db.SanPham.Include(s => s.DoiTuong).Include(s => s.TheLoai).Where(x => x.IDDoiTuong == IDDoiTuong).ToList();
            }

            if (IDTheLoai != null && IDTheLoai != 0 && (IDDoiTuong == null || IDDoiTuong == 0))
            {
                sanPham = db.SanPham.Include(s => s.DoiTuong).Include(s => s.TheLoai).Where(x => x.IDTheLoai == IDTheLoai).ToList();
            }
            List<DoiTuong> doituongl = new List<DoiTuong> { };
            doituongl.Add(new DoiTuong { ID = 0, TenDoiTuong = "All" });
            var doiTuongList = db.DoiTuong.ToList();

            foreach (var i in doiTuongList)
            {
                doituongl.Add(new DoiTuong { ID = i.ID, TenDoiTuong = i.TenDoiTuong });
            }

            List<TheLoai> theloail = new List<TheLoai> { };
            theloail.Add(new TheLoai { ID = 0, TenTheLaoi = "All" });
            var theloailist = db.TheLoai.ToList();

            foreach (var i in theloailist)
            {
                theloail.Add(new TheLoai { ID = i.ID, TenTheLaoi = i.TenTheLaoi });
            }

            ViewBag.IDDoiTuong = new SelectList(doituongl, "ID", "TenDoiTuong");
            ViewBag.IDTheLoai = new SelectList(theloail, "ID", "TenTheLaoi");
            return View(sanPham.ToList());
        }
        // GET: Shoper/SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: Shoper/SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.IDDoiTuong = new SelectList(db.DoiTuong, "ID", "TenDoiTuong");
            ViewBag.IDTheLoai = new SelectList(db.TheLoai, "ID", "TenTheLaoi");
            return View();
        }

        // POST: Shoper/SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenSanPham,Gia,SoLuong,HinhAnh,IDDoiTuong,IDTheLoai")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPham.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDDoiTuong = new SelectList(db.DoiTuong, "ID", "TenDoiTuong", sanPham.IDDoiTuong);
            ViewBag.IDTheLoai = new SelectList(db.TheLoai, "ID", "TenTheLaoi", sanPham.IDTheLoai);
            return View(sanPham);
        }

        // GET: Shoper/SanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDoiTuong = new SelectList(db.DoiTuong, "ID", "TenDoiTuong", sanPham.IDDoiTuong);
            ViewBag.IDTheLoai = new SelectList(db.TheLoai, "ID", "TenTheLaoi", sanPham.IDTheLoai);
            return View(sanPham);
        }

        // POST: Shoper/SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenSanPham,Gia,SoLuong,HinhAnh,IDDoiTuong,IDTheLoai")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDDoiTuong = new SelectList(db.DoiTuong, "ID", "TenDoiTuong", sanPham.IDDoiTuong);
            ViewBag.IDTheLoai = new SelectList(db.TheLoai, "ID", "TenTheLaoi", sanPham.IDTheLoai);
            return View(sanPham);
        }

        // GET: Shoper/SanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Shoper/SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPham.Find(id);
            db.SanPham.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}
