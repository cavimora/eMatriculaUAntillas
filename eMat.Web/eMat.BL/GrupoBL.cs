using eMat.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


namespace eMat.BL
{
    public class GrupoBL
    {
        eMatriculaEntities ent;
        public List<tbGrupo> getGruposByIdCurso(string idCurso)
        {
            using (ent = new eMatriculaEntities())
            {
                List<tbGrupo> res = ent.tbGrupo
                    .Include(m => m.tbCurso)
                    .Where(m => m.idCurso == idCurso).ToList();
                return res;
            }
        }
    }
}
