using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCOgrenciKayit.Models;

namespace MVCOgrenciKayit.Controllers
{

    public class OgrsController : Controller
    {
        private MVCOgrenciKayitEntities db = new MVCOgrenciKayitEntities();

        [Display(Name = "Öğrenci Soyadı")]
        public string OgrSoyad
        {
            get; set;
        }
        // GET: Ogrs
        public ActionResult Index()
        {
            @ViewBag.Sure = DateTime.Now.ToString("dd MMMM yy");
            return View(db.Ogr.ToList());
        }

        // GET: Ogrs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogr ogr = db.Ogr.Find(id);
            if (ogr == null)
            {
                return HttpNotFound();
            }
            return View(ogr);
        }

        // GET: Ogrs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ogrs/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ogr   Id,Og       rAd,OgrSoyad,OgrMail,OgrFotoğraf,OgrAdres")] Ogr ogr)
        {
            if (ModelState.IsValid)
            {
                db.Ogr.Add(ogr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ogr);
        }

        // GET: Ogrs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogr ogr = db.Ogr.Find(id);
            if (ogr == null)
            {
                return HttpNotFound();
            }
            return View(ogr);
        }

        // POST: Ogrs/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OgrId,OgrAd,OgrSoyad,OgrMail,OgrFotoğraf,OgrAdres")] Ogr ogr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ogr);
        }

        // GET: Ogrs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogr ogr = db.Ogr.Find(id);
            if (ogr == null)
            {
                return HttpNotFound();
            }
            return View(ogr);
        }

        // POST: Ogrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ogr ogr = db.Ogr.Find(id);
            db.Ogr.Remove(ogr);
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
