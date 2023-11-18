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
    public class DoiTuongsController : Controller
    {
        private ThayThuanMVCEntities db = new ThayThuanMVCEntities();

        // GET: ADMIN/DoiTuongs
        public ActionResult Index()
        {
            return View(db.DoiTuong.ToList());
        }

        // GET: ADMIN/DoiTuongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoiTuong doiTuong = db.DoiTuong.Find(id);
            if (doiTuong == null)
            {
                return HttpNotFound();
            }
            return View(doiTuong);
        }

        // GET: ADMIN/DoiTuongs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ADMIN/DoiTuongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenDoiTuong")] DoiTuong doiTuong)
        {
            if (ModelState.IsValid)
            {
                db.DoiTuong.Add(doiTuong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doiTuong);
        }

        // GET: ADMIN/DoiTuongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoiTuong doiTuong = db.DoiTuong.Find(id);
            if (doiTuong == null)
            {
                return HttpNotFound();
            }
            return View(doiTuong);
        }

        // POST: ADMIN/DoiTuongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenDoiTuong")] DoiTuong doiTuong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doiTuong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doiTuong);
        }

        // GET: ADMIN/DoiTuongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoiTuong doiTuong = db.DoiTuong.Find(id);
            if (doiTuong == null)
            {
                return HttpNotFound();
            }
            return View(doiTuong);
        }

        // POST: ADMIN/DoiTuongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoiTuong doiTuong = db.DoiTuong.Find(id);
            if (!db.SanPham.Any(x => x.IDDoiTuong == id))
            {
                db.DoiTuong.Remove(doiTuong);
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
