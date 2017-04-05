using eMat.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace eMat.BL
{
    public class CarrerasBL
    {
        eMatriculaEntities ent;

        public List<tbCurso> getCursosXCarrera(string siglaCarrera)
        {
            using (ent = new eMatriculaEntities())
            {

                List<tbCurso> res = ent.tbCurso.SqlQuery("select curso.* from [dbo].[tbCurso] as curso inner join[dbo].[tbCursoXPlan] as plancurso on plancurso.idCurso = curso.idCurso where plancurso.sigla like '%IS%'").ToList();
                                   
                return res;
            }
        }

    }
}
