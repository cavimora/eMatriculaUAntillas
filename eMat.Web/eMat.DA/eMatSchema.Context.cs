﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class eMatriculaEntities : DbContext
    {
        public eMatriculaEntities()
            : base("name=eMatriculaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tbCarrera> tbCarrera { get; set; }
        public DbSet<tbCurso> tbCurso { get; set; }
        public DbSet<tbEstudiante> tbEstudiante { get; set; }
        public DbSet<tbGrupo> tbGrupo { get; set; }
        public DbSet<tbMatricula> tbMatricula { get; set; }
        public DbSet<tbPlanEstudio> tbPlanEstudio { get; set; }
    }
}
