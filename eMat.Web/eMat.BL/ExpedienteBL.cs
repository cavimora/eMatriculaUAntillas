using eMat.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace eMat.BL
{
    public class ExpedienteBL
    {
        eMatriculaEntities ent;
        public List<tbMatricula> getExpediente(int carnet, int anioActual, int cuatriActual)
        {
            using (ent = new eMatriculaEntities())
            {
                //List<tbMatricula> res = (from es in ent.tbMatricula
                //                         where es.carnet == carnet &&
                //                         (es.anio + es.cuatrimestre != anioActual + cuatriActual)
                //                         select es).ToList();
                List<tbMatricula> res = ent.tbMatricula
                                            .Include(b => b.tbGrupo)
                                            .Include(b => b.tbGrupo.tbCurso)
                                            .Where(m => m.anio.ToString() + m.cuatrimestre.ToString() != anioActual.ToString() + cuatriActual.ToString() && m.carnet == carnet)
                                            .ToList();
                return res;

            }
        }

        public List<tbMatricula> getActual(int carnet, int anioActual, int cuatriActual)
        {
            using (ent = new eMatriculaEntities())
            {
                //List<tbMatricula> res = (from es in ent.tbMatricula
                //                         where es.carnet == carnet &&
                //                         (es.anio + es.cuatrimestre != anioActual + cuatriActual)
                //                         select es).ToList();
                List<tbMatricula> res = ent.tbMatricula
                                            .Include(b => b.tbGrupo)
                                            .Include(b => b.tbGrupo.tbCurso)
                                            .Where(m => m.anio.ToString() + m.cuatrimestre.ToString() == anioActual.ToString() + cuatriActual.ToString() && m.carnet == carnet)
                                            .ToList();
                return res;

            }
        }
    }
}
