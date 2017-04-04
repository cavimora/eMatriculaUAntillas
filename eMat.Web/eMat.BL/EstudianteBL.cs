using eMat.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMat.BL
{
    public class EstudianteBL
    {
        eMatriculaEntities db;
        public tbEstudiante validarEstudiante(tbEstudiante estudiante)
        {
            using(db = new eMatriculaEntities())
            {
                tbEstudiante res = (from es in db.tbEstudiante
                          where es.cedula.Trim() == estudiante.cedula.Trim() &&
                          es.contrasena.Trim() == estudiante.contrasena.Trim()
                          select es).FirstOrDefault();
                return res;
            }
        }
    }
}
