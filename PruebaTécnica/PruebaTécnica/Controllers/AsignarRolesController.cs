using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaTécnica.Modelo;

namespace PruebaTécnica.Controllers
{
    public class AsignarRolesController : Controller
    {
        private DBPruebaEntities1 db = new DBPruebaEntities1();

        // GET: AsignarRoles
        public ActionResult Index()
        {
            var uSERROL = db.USERROL.Include(u => u.ROLES).Include(u => u.USUARIOS);
            return View(uSERROL.ToList());
        }

        // GET: AsignarRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERROL uSERROL = db.USERROL.Find(id);
            if (uSERROL == null)
            {
                return HttpNotFound();
            }
            return View(uSERROL);
        }

        // GET: AsignarRoles/Create
        public ActionResult Create()
        {
            ViewBag.IDRol = new SelectList(db.ROLES, "ID", "Nombre");
            ViewBag.IDUser = new SelectList(db.USUARIOS, "ID", "Nombre");
            return View();
        }

        // POST: AsignarRoles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDUser,IDRol")] USERROL uSERROL)
        {
            if (ModelState.IsValid)
            {
                db.USERROL.Add(uSERROL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDRol = new SelectList(db.ROLES, "ID", "Nombre", uSERROL.IDRol);
            ViewBag.IDUser = new SelectList(db.USUARIOS, "ID", "Nombre", uSERROL.IDUser);
            return View(uSERROL);
        }

        // GET: AsignarRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERROL uSERROL = db.USERROL.Find(id);
            if (uSERROL == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDRol = new SelectList(db.ROLES, "ID", "Nombre", uSERROL.IDRol);
            ViewBag.IDUser = new SelectList(db.USUARIOS, "ID", "Nombre", uSERROL.IDUser);
            return View(uSERROL);
        }

        // POST: AsignarRoles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDUser,IDRol")] USERROL uSERROL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSERROL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDRol = new SelectList(db.ROLES, "ID", "Nombre", uSERROL.IDRol);
            ViewBag.IDUser = new SelectList(db.USUARIOS, "ID", "Nombre", uSERROL.IDUser);
            return View(uSERROL);
        }

        // GET: AsignarRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERROL uSERROL = db.USERROL.Find(id);
            if (uSERROL == null)
            {
                return HttpNotFound();
            }
            return View(uSERROL);
        }

        // POST: AsignarRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USERROL uSERROL = db.USERROL.Find(id);
            db.USERROL.Remove(uSERROL);
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
