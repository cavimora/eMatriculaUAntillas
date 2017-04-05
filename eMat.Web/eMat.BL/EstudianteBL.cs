using eMat.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace eMat.BL
{
    public class EstudianteBL
    {
        eMatriculaEntities db;
        public tbEstudiante validarEstudiante(tbEstudiante estudiante)
        {
            using(db = new eMatriculaEntities())
            {
                //tbEstudiante res = (from es in db.tbEstudiante
                //          where es.cedula.Trim() == estudiante.cedula.Trim() &&
                //          es.contrasena.Trim() == estudiante.contrasena.Trim()
                //          select es).FirstOrDefault();
                tbEstudiante res = db.tbEstudiante
                                    .Include(m => m.tbCarrera)
                                    .Include(m => m.tbMatricula)
                                    .Where(m => m.cedula.Trim() == estudiante.cedula.Trim() && m.contrasena.Trim() == estudiante.contrasena.Trim()).FirstOrDefault();
                return res;
            }
        }
    }
}
