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
    public class GruposController : Controller
    {
        private eMatriculaEntities db = new eMatriculaEntities();

        // GET: tbGrupoes
        public async Task<ActionResult> Index()
        {
            var tbGrupo = db.tbGrupo.Include(t => t.tbCurso);
            return View(await tbGrupo.ToListAsync());
        }

        // GET: tbGrupoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbGrupo tbGrupo = await db.tbGrupo.FindAsync(id);
            if (tbGrupo == null)
            {
                return HttpNotFound();
            }
            return View(tbGrupo);
        }

        // GET: tbGrupoes/Create
        public ActionResult Create()
        {
            ViewBag.idCurso = new SelectList(db.tbCurso, "idCurso", "nombre");
            return View();
        }

        // POST: tbGrupoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idGrupo,idCurso,horario")] tbGrupo tbGrupo)
        {
            if (ModelState.IsValid)
            {
                db.tbGrupo.Add(tbGrupo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idCurso = new SelectList(db.tbCurso, "idCurso", "nombre", tbGrupo.idCurso);
            return View(tbGrupo);
        }

        // GET: tbGrupoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbGrupo tbGrupo = await db.tbGrupo.FindAsync(id);
            if (tbGrupo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCurso = new SelectList(db.tbCurso, "idCurso", "nombre", tbGrupo.idCurso);
            return View(tbGrupo);
        }

        // POST: tbGrupoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idGrupo,idCurso,horario")] tbGrupo tbGrupo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbGrupo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idCurso = new SelectList(db.tbCurso, "idCurso", "nombre", tbGrupo.idCurso);
            return View(tbGrupo);
        }

        // GET: tbGrupoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbGrupo tbGrupo = await db.tbGrupo.FindAsync(id);
            if (tbGrupo == null)
            {
                return HttpNotFound();
            }
            return View(tbGrupo);
        }

        // POST: tbGrupoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbGrupo tbGrupo = await db.tbGrupo.FindAsync(id);
            db.tbGrupo.Remove(tbGrupo);
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
