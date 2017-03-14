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
    public class EstudiantesController : Controller
    {
        private eMatriculaEntities db = new eMatriculaEntities();

        // GET: Estudiantes
        public async Task<ActionResult> Index()
        {
            return View(await db.tbEstudiante.ToListAsync());
        }

        // GET: Estudiantes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEstudiante tbEstudiante = await db.tbEstudiante.FindAsync(id);
            if (tbEstudiante == null)
            {
                return HttpNotFound();
            }
            return View(tbEstudiante);
        }

        // GET: Estudiantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estudiantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "carnet,cedula,nombre,apellidos,direccion,email,telefono,contrasena")] tbEstudiante tbEstudiante)
        {
            if (ModelState.IsValid)
            {
                db.tbEstudiante.Add(tbEstudiante);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tbEstudiante);
        }

        // GET: Estudiantes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEstudiante tbEstudiante = await db.tbEstudiante.FindAsync(id);
            if (tbEstudiante == null)
            {
                return HttpNotFound();
            }
            return View(tbEstudiante);
        }

        // POST: Estudiantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "carnet,cedula,nombre,apellidos,direccion,email,telefono,contrasena")] tbEstudiante tbEstudiante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbEstudiante).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbEstudiante);
        }

        // GET: Estudiantes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEstudiante tbEstudiante = await db.tbEstudiante.FindAsync(id);
            if (tbEstudiante == null)
            {
                return HttpNotFound();
            }
            return View(tbEstudiante);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbEstudiante tbEstudiante = await db.tbEstudiante.FindAsync(id);
            db.tbEstudiante.Remove(tbEstudiante);
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
