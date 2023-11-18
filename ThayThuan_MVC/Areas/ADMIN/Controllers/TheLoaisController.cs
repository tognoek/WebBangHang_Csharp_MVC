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
    public class TheLoaisController : Controller
    {
        private ThayThuanMVCEntities db = new ThayThuanMVCEntities();

        // GET: ADMIN/TheLoais
        public ActionResult Index()
        {
            return View(db.TheLoai.ToList());
        }

        // GET: ADMIN/TheLoais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheLoai theLoai = db.TheLoai.Find(id);
            if (theLoai == null)
            {
                return HttpNotFound();
            }
            return View(theLoai);
        }

        // GET: ADMIN/TheLoais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ADMIN/TheLoais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenTheLaoi")] TheLoai theLoai)
        {
            if (ModelState.IsValid)
            {
                db.TheLoai.Add(theLoai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(theLoai);
        }

        // GET: ADMIN/TheLoais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheLoai theLoai = db.TheLoai.Find(id);
            if (theLoai == null)
            {
                return HttpNotFound();
            }
            return View(theLoai);
        }

        // POST: ADMIN/TheLoais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenTheLaoi")] TheLoai theLoai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(theLoai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(theLoai);
        }

        // GET: ADMIN/TheLoais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheLoai theLoai = db.TheLoai.Find(id);
            if (theLoai == null)
            {
                return HttpNotFound();
            }
            return View(theLoai);
        }

        // POST: ADMIN/TheLoais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TheLoai theLoai = db.TheLoai.Find(id);
            if (!db.SanPham.Any(x => x.IDTheLoai == id))
            {
                db.TheLoai.Remove(theLoai);
                db.SaveChanges();
            }
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
