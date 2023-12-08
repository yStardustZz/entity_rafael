using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using entity_rafael.Models;

namespace entity_rafael.Controllers
{
    public class AtletasController : Controller
    {
        private esportesEntities db = new esportesEntities();

        // GET: Atletas
        public ActionResult Index()
        {
            return View(db.Atleta.ToList());
        }

        // GET: Atletas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atleta atleta = db.Atleta.Find(id);
            if (atleta == null)
            {
                return HttpNotFound();
            }
            return View(atleta);
        }

        // GET: Atletas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Atletas/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAtleta,nome,esporte,idade")] Atleta atleta)
        {
            if (ModelState.IsValid)
            {
                db.Atleta.Add(atleta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(atleta);
        }

        // GET: Atletas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atleta atleta = db.Atleta.Find(id);
            if (atleta == null)
            {
                return HttpNotFound();
            }
            return View(atleta);
        }

        // POST: Atletas/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAtleta,nome,esporte,idade")] Atleta atleta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atleta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(atleta);
        }

        // GET: Atletas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atleta atleta = db.Atleta.Find(id);
            if (atleta == null)
            {
                return HttpNotFound();
            }
            return View(atleta);
        }

        // POST: Atletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atleta atleta = db.Atleta.Find(id);
            db.Atleta.Remove(atleta);
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
