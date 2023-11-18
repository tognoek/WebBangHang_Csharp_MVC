using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThayThuan_MVC;

namespace ThayThuan_MVC.Areas.ADMIN.Controllers
{
    public class NguoiDungsController : Controller
    {
        private ThayThuanMVCEntities db = new ThayThuanMVCEntities();

        // GET: ADMIN/NguoiDungs
        public ActionResult Index()
        {
            var nguoiDung = db.NguoiDung.Include(n => n.Quyen);
            return View(nguoiDung.ToList());
        }

        // GET: ADMIN/NguoiDungs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = db.NguoiDung.Find(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDung);
        }

        // GET: ADMIN/NguoiDungs/Create
        public ActionResult Create()
        {
            ViewBag.IDQuyen = new SelectList(db.Quyen, "ID", "TenQuyen");
            return View();
        }

        // POST: ADMIN/NguoiDungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,Password,IDQuyen,HoTen,SoDienThoai,Email")] NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.NguoiDung.Add(nguoiDung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDQuyen = new SelectList(db.Quyen, "ID", "TenQuyen", nguoiDung.IDQuyen);
            return View(nguoiDung);
        }

        // GET: ADMIN/NguoiDungs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = db.NguoiDung.Find(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDQuyen = new SelectList(db.Quyen, "ID", "TenQuyen", nguoiDung.IDQuyen);
            return View(nguoiDung);
        }

        // POST: ADMIN/NguoiDungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,Password,IDQuyen,HoTen,SoDienThoai,Email")] NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nguoiDung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDQuyen = new SelectList(db.Quyen, "ID", "TenQuyen", nguoiDung.IDQuyen);
            return View(nguoiDung);
        }

        // GET: ADMIN/NguoiDungs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = db.NguoiDung.Find(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDung);
        }

        // POST: ADMIN/NguoiDungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NguoiDung nguoiDung = db.NguoiDung.Find(id);
            db.NguoiDung.Remove(nguoiDung);
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
