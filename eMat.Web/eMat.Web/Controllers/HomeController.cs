using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eMat.DA;
using eMat.BL;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace eMat.Web.Controllers
{
    public class HomeController : Controller
    {

        //private eMatriculaEntities db = new eMatriculaEntities();
        private EstudianteBL estudiante;

        // GET: Home
        public ActionResult Index()
        {
            if (((eMat.DA.tbEstudiante)Session["estudiante"]) == null)
                ViewBag.vertMenu = "none";
            else
                ViewBag.vertMenu = "perfil";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "cedula,contrasena")] tbEstudiante estudiante)
        {
            //tbEstud.con
            if (ModelState.IsValid)
            {
                this.estudiante = new EstudianteBL();
                estudiante = this.estudiante.validarEstudiante(estudiante);

                Session["estudiante"] = estudiante;
                ViewBag.vertMenu = "perfil";
                //db.tbCarrera.(tbCarrera);
                //await db.SaveChangesAsync();
                //return RedirectToAction("Index");
            }

            //ViewBag.sigla = new SelectList(db.tbPlanEstudio, "sigla", "nombre", tbEstudiante.sigla);
            return View(estudiante);
        }
    }
}