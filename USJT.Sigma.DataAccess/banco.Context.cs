﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace USJT.Sigma.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SIGMAEntities : DbContext
    {
        public SIGMAEntities()
            : base("name=SIGMAEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TB_ALUNO> TB_ALUNO { get; set; }
        public virtual DbSet<TB_ATIVIDADE> TB_ATIVIDADE { get; set; }
        public virtual DbSet<TB_ATIVIDADE_ALUNO> TB_ATIVIDADE_ALUNO { get; set; }
        public virtual DbSet<TB_CERTIFICADO> TB_CERTIFICADO { get; set; }
        public virtual DbSet<TB_SUBTOPICO> TB_SUBTOPICO { get; set; }
        public virtual DbSet<TB_TOPICO> TB_TOPICO { get; set; }
        public virtual DbSet<TB_VIDEO> TB_VIDEO { get; set; }
    }
}
