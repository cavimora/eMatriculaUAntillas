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
using eMat.BL;

namespace eMat.Web.Controllers
{
    public class MatriculaController : Controller
    {
        private eMatriculaEntities db = new eMatriculaEntities();
        private CarrerasBL carreras;

        // GET: Matricula
        public async Task<ActionResult> Index()
        {
            //ViewBag.vertMenu = "matricula";
            if (((eMat.DA.tbEstudiante)Session["estudiante"]) == null)
                ViewBag.vertMenu = "none";
            else
            {
                tbEstudiante est = ((eMat.DA.tbEstudiante)Session["estudiante"]);
                ViewBag.vertMenu = "matricula";
                carreras = new CarrerasBL();
                return View(carreras.getCursosXCarrera(est.tbCarrera.FirstOrDefault().sigla));
            }

            return View();
        }

        // GET: Matricula/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMatricula tbMatricula = await db.tbMatricula.FindAsync(id);
            if (tbMatricula == null)
            {
                return HttpNotFound();
            }
            return View(tbMatricula);
        }

        // GET: Matricula/Create
        public ActionResult Create()
        {
            ViewBag.carnet = new SelectList(db.tbEstudiante, "carnet", "cedula");
            ViewBag.idGrupo = new SelectList(db.tbGrupo, "idGrupo", "idCurso");
            return View();
        }

        // POST: Matricula/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "carnet,idGrupo,cuatrimestre,anio,nota")] tbMatricula tbMatricula)
        {
            if (ModelState.IsValid)
            {
                db.tbMatricula.Add(tbMatricula);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.carnet = new SelectList(db.tbEstudiante, "carnet", "cedula", tbMatricula.carnet);
            ViewBag.idGrupo = new SelectList(db.tbGrupo, "idGrupo", "idCurso", tbMatricula.idGrupo);
            return View(tbMatricula);
        }

        // GET: Matricula/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMatricula tbMatricula = await db.tbMatricula.FindAsync(id);
            if (tbMatricula == null)
            {
                return HttpNotFound();
            }
            ViewBag.carnet = new SelectList(db.tbEstudiante, "carnet", "cedula", tbMatricula.carnet);
            ViewBag.idGrupo = new SelectList(db.tbGrupo, "idGrupo", "idCurso", tbMatricula.idGrupo);
            return View(tbMatricula);
        }

        // POST: Matricula/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "carnet,idGrupo,cuatrimestre,anio,nota")] tbMatricula tbMatricula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbMatricula).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.carnet = new SelectList(db.tbEstudiante, "carnet", "cedula", tbMatricula.carnet);
            ViewBag.idGrupo = new SelectList(db.tbGrupo, "idGrupo", "idCurso", tbMatricula.idGrupo);
            return View(tbMatricula);
        }

        // GET: Matricula/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMatricula tbMatricula = await db.tbMatricula.FindAsync(id);
            if (tbMatricula == null)
            {
                return HttpNotFound();
            }
            return View(tbMatricula);
        }

        // POST: Matricula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbMatricula tbMatricula = await db.tbMatricula.FindAsync(id);
            db.tbMatricula.Remove(tbMatricula);
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
