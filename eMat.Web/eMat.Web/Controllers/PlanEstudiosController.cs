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

namespace eMat.Web.Controllers
{
    public class PlanEstudiosController : Controller
    {
        private eMatriculaEntities db = new eMatriculaEntities();

        // GET: tbPlanEstudios
        public async Task<ActionResult> Index()
        {
            var tbPlanEstudio = db.tbPlanEstudio.Include(t => t.tbCarrera);
            return View(await tbPlanEstudio.ToListAsync());
        }

        // GET: tbPlanEstudios/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPlanEstudio tbPlanEstudio = await db.tbPlanEstudio.FindAsync(id);
            if (tbPlanEstudio == null)
            {
                return HttpNotFound();
            }
            return View(tbPlanEstudio);
        }

        // GET: tbPlanEstudios/Create
        public ActionResult Create()
        {
            ViewBag.sigla = new SelectList(db.tbCarrera, "sigla", "carrera");
            return View();
        }

        // POST: tbPlanEstudios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "sigla,nombre")] tbPlanEstudio tbPlanEstudio)
        {
            if (ModelState.IsValid)
            {
                db.tbPlanEstudio.Add(tbPlanEstudio);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.sigla = new SelectList(db.tbCarrera, "sigla", "carrera", tbPlanEstudio.sigla);
            return View(tbPlanEstudio);
        }

        // GET: tbPlanEstudios/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPlanEstudio tbPlanEstudio = await db.tbPlanEstudio.FindAsync(id);
            if (tbPlanEstudio == null)
            {
                return HttpNotFound();
            }
            ViewBag.sigla = new SelectList(db.tbCarrera, "sigla", "carrera", tbPlanEstudio.sigla);
            return View(tbPlanEstudio);
        }

        // POST: tbPlanEstudios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "sigla,nombre")] tbPlanEstudio tbPlanEstudio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbPlanEstudio).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.sigla = new SelectList(db.tbCarrera, "sigla", "carrera", tbPlanEstudio.sigla);
            return View(tbPlanEstudio);
        }

        // GET: tbPlanEstudios/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPlanEstudio tbPlanEstudio = await db.tbPlanEstudio.FindAsync(id);
            if (tbPlanEstudio == null)
            {
                return HttpNotFound();
            }
            return View(tbPlanEstudio);
        }

        // POST: tbPlanEstudios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            tbPlanEstudio tbPlanEstudio = await db.tbPlanEstudio.FindAsync(id);
            db.tbPlanEstudio.Remove(tbPlanEstudio);
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
