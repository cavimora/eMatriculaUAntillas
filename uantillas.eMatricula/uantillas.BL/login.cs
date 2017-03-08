using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uantillas.DA;

namespace uantillas.BL
{
    public class login
    {
        eMatriculaEntities scheme;

        public tbEstudiante attemptLogin(string cedula, string password)
        {
            tbEstudiante est;

            try
            {
                using(scheme = new eMatriculaEntities())
                {
                    est = (from q in scheme.tbEstudiante
                          where q.cedula == cedula && q.contrasena == password
                          select q).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {

                est = null;
            }

            return est;
        }
    }
}
