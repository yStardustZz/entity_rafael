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
    public class EsportesController : Controller
    {
        private esportesEntities db = new esportesEntities();

        // GET: Esportes
        public ActionResult Index()
        {
            var esporte = db.Esporte.Include(e => e.Atleta);
            return View(esporte.ToList());
        }

        // GET: Esportes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Esporte esporte = db.Esporte.Find(id);
            if (esporte == null)
            {
                return HttpNotFound();
            }
            return View(esporte);
        }

        // GET: Esportes/Create
        public ActionResult Create()
        {
            ViewBag.NumAtletas = new SelectList(db.Atleta, "IdAtleta", "nome");
            return View();
        }

        // POST: Esportes/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEsporte,nome,NumAtletas")] Esporte esporte)
        {
            if (ModelState.IsValid)
            {
                db.Esporte.Add(esporte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NumAtletas = new SelectList(db.Atleta, "IdAtleta", "nome", esporte.NumAtletas);
            return View(esporte);
        }

        // GET: Esportes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Esporte esporte = db.Esporte.Find(id);
            if (esporte == null)
            {
                return HttpNotFound();
            }
            ViewBag.NumAtletas = new SelectList(db.Atleta, "IdAtleta", "nome", esporte.NumAtletas);
            return View(esporte);
        }

        // POST: Esportes/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEsporte,nome,NumAtletas")] Esporte esporte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(esporte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NumAtletas = new SelectList(db.Atleta, "IdAtleta", "nome", esporte.NumAtletas);
            return View(esporte);
        }

        // GET: Esportes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Esporte esporte = db.Esporte.Find(id);
            if (esporte == null)
            {
                return HttpNotFound();
            }
            return View(esporte);
        }

        // POST: Esportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Esporte esporte = db.Esporte.Find(id);
            db.Esporte.Remove(esporte);
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
