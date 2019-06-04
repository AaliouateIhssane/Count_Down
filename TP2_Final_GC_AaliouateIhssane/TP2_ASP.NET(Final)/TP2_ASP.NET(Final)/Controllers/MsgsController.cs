using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TP2_ASP.NET_Final_.Models;

namespace TP2_ASP.NET_Final_.Controllers
{
    public class MsgsController : Controller
    {
        private TP2_dbEntities db = new TP2_dbEntities();

        // GET: Msgs
        public ActionResult Index()
        {
            return View(db.Msgs.ToList());
        }

        // GET: Msgs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Msg msg = db.Msgs.Find(id);
            if (msg == null)
            {
                return HttpNotFound();
            }
            return View(msg);
        }

        // GET: Msgs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Msgs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Email,UserName,mssg,DateM")] Msg msg)
        {
            if (ModelState.IsValid)
            {
                db.Msgs.Add(msg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(msg);
        }

        // GET: Msgs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Msg msg = db.Msgs.Find(id);
            if (msg == null)
            {
                return HttpNotFound();
            }
            return View(msg);
        }

        // POST: Msgs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Email,UserName,mssg,DateM")] Msg msg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(msg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(msg);
        }

        // GET: Msgs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Msg msg = db.Msgs.Find(id);
            if (msg == null)
            {
                return HttpNotFound();
            }
            return View(msg);
        }

        // POST: Msgs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Msg msg = db.Msgs.Find(id);
            db.Msgs.Remove(msg);
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
