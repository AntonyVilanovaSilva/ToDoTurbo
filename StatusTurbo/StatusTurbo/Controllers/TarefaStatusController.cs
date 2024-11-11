using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StatusTurbo.Models;

namespace StatusTurbo.Controllers
{
    public class TarefaStatusController : Controller
    {
        private StatusTurboEntities db = new StatusTurboEntities();

        // GET: TarefaStatus
        public ActionResult Index()
        {
            return View(db.TarefaStatus.ToList());
        }

        // GET: TarefaStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TarefaStatus tarefaStatus = db.TarefaStatus.Find(id);
            if (tarefaStatus == null)
            {
                return HttpNotFound();
            }
            return View(tarefaStatus);
        }

        // GET: TarefaStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TarefaStatus/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdStatus,DescricaoStatus")] TarefaStatus tarefaStatus)
        {
            if (ModelState.IsValid)
            {
                db.TarefaStatus.Add(tarefaStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tarefaStatus);
        }

        // GET: TarefaStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TarefaStatus tarefaStatus = db.TarefaStatus.Find(id);
            if (tarefaStatus == null)
            {
                return HttpNotFound();
            }
            return View(tarefaStatus);
        }

        // POST: TarefaStatus/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdStatus,DescricaoStatus")] TarefaStatus tarefaStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarefaStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tarefaStatus);
        }

        // GET: TarefaStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TarefaStatus tarefaStatus = db.TarefaStatus.Find(id);
            if (tarefaStatus == null)
            {
                return HttpNotFound();
            }
            return View(tarefaStatus);
        }

        // POST: TarefaStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TarefaStatus tarefaStatus = db.TarefaStatus.Find(id);
            db.TarefaStatus.Remove(tarefaStatus);
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
