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
    public class registersController : Controller
    {
        private TP2_dbEntities db = new TP2_dbEntities();

        // GET: registers
        public ActionResult Index()
        {
            return View(db.registers.ToList());
        }

        // GET: registers/Details/5
        public ActionResult Details(string UserName, string email)
        {
            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            register register = db.registers.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);*/

            Confirm cf = new Confirm();
            cf.Confirmation(email, "Bonjour " + UserName + " votre inscription est complete Bievenu sur Orchestra David Garett !!", "Confirmation d'nscription ");

            return RedirectToAction("Index");
        }

        // GET: registers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: registers/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,UserName,UserPassword,job,email,Photo,DateR")] register register)
        {
            if (ModelState.IsValid)
            {
                db.registers.Add(register);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(register);
        }

        // GET: registers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            register register = db.registers.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);
        }

        // POST: registers/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UserName,UserPassword,job,email,Photo,DateR")] register register)
        {
            if (ModelState.IsValid)
            {
                db.Entry(register).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(register);
        }

        // GET: registers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            register register = db.registers.Find(id);
            if (register == null)
            {
                return HttpNotFound();
            }
            return View(register);
        }

        // POST: registers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string UserName, string email)
        {
            register register = db.registers.Find(id);
            db.registers.Remove(register);
            db.SaveChanges();

            Confirm cf = new Confirm();
            cf.Confirmation(email, "Bonjour " + UserName + " votre inscription est refuser sur Orchestra David Garett !!", "Confirmation d'nscription ");


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
