using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eMat.DA;
using eMat.BL;
using System.Threading.Tasks;

namespace eMat.Web.Controllers
{
    public class HomeController : Controller
    {

        //private eMatriculaEntities db = new eMatriculaEntities();
        private EstudianteController estudiante;
        
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.vertMenu = "none";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "cedula,contrasena")] tbEstudiante estudiante)
        {
            //tbEstud.con
            if (ModelState.IsValid)
            {
                this.estudiante = new EstudianteController();
                estudiante = this.estudiante.validarEstudiante(estudiante);
                //db.tbCarrera.(tbCarrera);
                //await db.SaveChangesAsync();
                //return RedirectToAction("Index");
            }

            //ViewBag.sigla = new SelectList(db.tbPlanEstudio, "sigla", "nombre", tbEstudiante.sigla);
            return View(estudiante);
        }
    }
}