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

                //List<tbCurso> res = (ent.tbCurso.Include(m => m.tbCurso1)
                //        .SqlQuery("select curso.* from [dbo].[tbCurso] as curso " +
                //        "inner join[dbo].[tbCursoXPlan] " +
                //        "as plancurso on plancurso.idCurso = curso.idCurso" +
                //        "where plancurso.sigla like '%" + siglaCarrera + "%'")).ToList();

                List<tbCurso> res1 = ent.tbCurso
                                        .Include(c => c.tbPlanEstudio)
                                        .Include(p => p.tbCurso1)
                                        .ToList();
                bool flag = false;
                List<tbCurso> res = new List<tbCurso>();

                foreach (var i in res1)
                {
                    flag = false;
                    foreach(var p in i.tbPlanEstudio)
                    {
                        if (p.sigla.Contains(siglaCarrera))
                        {
                            res.Add(i);
                        }
                    }
                }


                return res;
            }
        }

    }
}
