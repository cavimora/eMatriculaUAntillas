using eMat.BL;
using eMat.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eMat.Web.Controllers
{
    public class PerfilController : Controller
    {
        // GET: Perfil
        ExpedienteBL expediente;
        public ActionResult Index()
        {
            return View();
        }

        //GET: Perfil/Expediente
        public ActionResult Expediente()
        {
            expediente = new ExpedienteBL();
            tbEstudiante est = ((tbEstudiante)Session["estudiante"]);
            return View(expediente.getExpediente(est.carnet, 2017, 1));
        }

        public ActionResult Actual()
        {
            expediente = new ExpedienteBL();
            tbEstudiante est = ((tbEstudiante)Session["estudiante"]);
            return View(expediente.getActual(est.carnet, 2017, 1));
        }
    }
}