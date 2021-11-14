using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FINAL;

namespace KARENEXAMENFINAL.Views
{
    public class CURSOSController : Controller
    {
        private KFINALEntities db = new KFINALEntities();

        // GET: CURSOS
        public ActionResult Index()
        {
            return View(db.CURSOS.ToList());
        }

        // GET: CURSOS/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CURSOS cURSOS = db.CURSOS.Find(id);
            if (cURSOS == null)
            {
                return HttpNotFound();
            }
            return View(cURSOS);
        }

        // GET: CURSOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CURSOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Cursos,Nombre_Curso,Creditos_Curso,Ano_Curso")] CURSOS cURSOS)
        {
            if (ModelState.IsValid)
            {
                db.CURSOS.Add(cURSOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cURSOS);
        }

        // GET: CURSOS/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CURSOS cURSOS = db.CURSOS.Find(id);
            if (cURSOS == null)
            {
                return HttpNotFound();
            }
            return View(cURSOS);
        }

        // POST: CURSOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Cursos,Nombre_Curso,Creditos_Curso,Ano_Curso")] CURSOS cURSOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cURSOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cURSOS);
        }

        // GET: CURSOS/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CURSOS cURSOS = db.CURSOS.Find(id);
            if (cURSOS == null)
            {
                return HttpNotFound();
            }
            return View(cURSOS);
        }

        // POST: CURSOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CURSOS cURSOS = db.CURSOS.Find(id);
            db.CURSOS.Remove(cURSOS);
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
