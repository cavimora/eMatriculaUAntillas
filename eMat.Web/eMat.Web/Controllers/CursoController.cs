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
    public class CursoController : Controller
    {
        private eMatriculaEntities db = new eMatriculaEntities();

        // GET: Curso
        public async Task<ActionResult> Index()
        {
            return View(await db.tbCurso.ToListAsync());
        }

        // GET: Curso/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCurso tbCurso = await db.tbCurso.FindAsync(id);
            if (tbCurso == null)
            {
                return HttpNotFound();
            }
            return View(tbCurso);
        }

        // GET: Curso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Curso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idCurso,nombre,creditos")] tbCurso tbCurso)
        {
            if (ModelState.IsValid)
            {
                db.tbCurso.Add(tbCurso);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tbCurso);
        }

        // GET: Curso/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCurso tbCurso = await db.tbCurso.FindAsync(id);
            if (tbCurso == null)
            {
                return HttpNotFound();
            }
            return View(tbCurso);
        }

        // POST: Curso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idCurso,nombre,creditos")] tbCurso tbCurso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbCurso).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbCurso);
        }

        // GET: Curso/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCurso tbCurso = await db.tbCurso.FindAsync(id);
            if (tbCurso == null)
            {
                return HttpNotFound();
            }
            return View(tbCurso);
        }

        // POST: Curso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            tbCurso tbCurso = await db.tbCurso.FindAsync(id);
            db.tbCurso.Remove(tbCurso);
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
