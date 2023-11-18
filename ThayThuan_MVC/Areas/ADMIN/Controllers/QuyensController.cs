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
    public class QuyensController : Controller
    {
        private ThayThuanMVCEntities db = new ThayThuanMVCEntities();

        // GET: ADMIN/Quyens
        public ActionResult Index()
        {
            return View(db.Quyen.ToList());
        }

        // GET: ADMIN/Quyens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quyen quyen = db.Quyen.Find(id);
            if (quyen == null)
            {
                return HttpNotFound();
            }
            return View(quyen);
        }

        // GET: ADMIN/Quyens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ADMIN/Quyens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenQuyen,MoTa")] Quyen quyen)
        {
            if (ModelState.IsValid)
            {
                db.Quyen.Add(quyen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quyen);
        }

        // GET: ADMIN/Quyens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quyen quyen = db.Quyen.Find(id);
            if (quyen == null)
            {
                return HttpNotFound();
            }
            return View(quyen);
        }

        // POST: ADMIN/Quyens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenQuyen,MoTa")] Quyen quyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quyen);
        }

        // GET: ADMIN/Quyens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quyen quyen = db.Quyen.Find(id);
            if (quyen == null)
            {
                return HttpNotFound();
            }
            return View(quyen);
        }

        // POST: ADMIN/Quyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quyen quyen = db.Quyen.Find(id);
            if (!db.NguoiDung.Any(x => x.IDQuyen == id))
            {
                db.Quyen.Remove(quyen);
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
