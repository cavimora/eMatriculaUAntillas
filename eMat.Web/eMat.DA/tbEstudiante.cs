//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eMat.DA
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbEstudiante
    {
        public tbEstudiante()
        {
            this.tbMatricula = new HashSet<tbMatricula>();
            this.tbCarrera = new HashSet<tbCarrera>();
        }
    
        public int carnet { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string contrasena { get; set; }
    
        public virtual ICollection<tbMatricula> tbMatricula { get; set; }
        public virtual ICollection<tbCarrera> tbCarrera { get; set; }
    }
}