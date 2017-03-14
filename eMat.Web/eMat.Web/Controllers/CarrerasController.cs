using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eMat.DA;

namespace eMat.Web.Views
{
    public class CarrerasController : Controller
    {
        private eMatriculaEntities db = new eMatriculaEntities();

        // GET: Carreras
        public async Task<ActionResult> Index()
        {
            var tbCarrera = db.tbCarrera.Include(t => t.tbPlanEstudio);
            return View(await tbCarrera.ToListAsync());
        }

        // GET: Carreras/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCarrera tbCarrera = await db.tbCarrera.FindAsync(id);
            if (tbCarrera == null)
            {
                return HttpNotFound();
            }
            return View(tbCarrera);
        }

        // GET: Carreras/Create
        public ActionResult Create()
        {
            ViewBag.sigla = new SelectList(db.tbPlanEstudio, "sigla", "nombre");
            return View();
        }

        // POST: Carreras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "sigla,carrera")] tbCarrera tbCarrera)
        {
            if (ModelState.IsValid)
            {
                db.tbCarrera.Add(tbCarrera);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.sigla = new SelectList(db.tbPlanEstudio, "sigla", "nombre", tbCarrera.sigla);
            return View(tbCarrera);
        }

        // GET: Carreras/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCarrera tbCarrera = await db.tbCarrera.FindAsync(id);
            if (tbCarrera == null)
            {
                return HttpNotFound();
            }
            ViewBag.sigla = new SelectList(db.tbPlanEstudio, "sigla", "nombre", tbCarrera.sigla);
            return View(tbCarrera);
        }

        // POST: Carreras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "sigla,carrera")] tbCarrera tbCarrera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbCarrera).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.sigla = new SelectList(db.tbPlanEstudio, "sigla", "nombre", tbCarrera.sigla);
            return View(tbCarrera);
        }

        // GET: Carreras/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCarrera tbCarrera = await db.tbCarrera.FindAsync(id);
            if (tbCarrera == null)
            {
                return HttpNotFound();
            }
            return View(tbCarrera);
        }

        // POST: Carreras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            tbCarrera tbCarrera = await db.tbCarrera.FindAsync(id);
            db.tbCarrera.Remove(tbCarrera);
            await db.SaveChangesAsync();
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
