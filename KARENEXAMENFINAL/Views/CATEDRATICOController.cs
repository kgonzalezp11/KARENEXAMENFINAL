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
    public class CATEDRATICOController : Controller
    {
        private KFINALEntities db = new KFINALEntities();

        // GET: CATEDRATICO
        public ActionResult Index()
        {
            return View(db.CATEDRATICO.ToList());
        }

        // GET: CATEDRATICO/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEDRATICO cATEDRATICO = db.CATEDRATICO.Find(id);
            if (cATEDRATICO == null)
            {
                return HttpNotFound();
            }
            return View(cATEDRATICO);
        }

        // GET: CATEDRATICO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CATEDRATICO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Catedratico,Nombre_Catedratico,Apellido_Catedratico,Telefono_Catedratico,Estado_Catedratico")] CATEDRATICO cATEDRATICO)
        {
            if (ModelState.IsValid)
            {
                db.CATEDRATICO.Add(cATEDRATICO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cATEDRATICO);
        }

        // GET: CATEDRATICO/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEDRATICO cATEDRATICO = db.CATEDRATICO.Find(id);
            if (cATEDRATICO == null)
            {
                return HttpNotFound();
            }
            return View(cATEDRATICO);
        }

        // POST: CATEDRATICO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Catedratico,Nombre_Catedratico,Apellido_Catedratico,Telefono_Catedratico,Estado_Catedratico")] CATEDRATICO cATEDRATICO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cATEDRATICO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cATEDRATICO);
        }

        // GET: CATEDRATICO/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEDRATICO cATEDRATICO = db.CATEDRATICO.Find(id);
            if (cATEDRATICO == null)
            {
                return HttpNotFound();
            }
            return View(cATEDRATICO);
        }

        // POST: CATEDRATICO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CATEDRATICO cATEDRATICO = db.CATEDRATICO.Find(id);
            db.CATEDRATICO.Remove(cATEDRATICO);
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
