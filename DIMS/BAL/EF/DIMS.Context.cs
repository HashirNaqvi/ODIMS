﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DIMS.BAL.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DIMSContainer : DbContext
    {
        public DIMSContainer()
            : base("name=DIMSContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DisasterInformation> DisasterInformation { get; set; }
        public virtual DbSet<NDMAUser> NDMAUser { get; set; }
        public virtual DbSet<PublicMessage> PublicMessage { get; set; }
        public virtual DbSet<ReliefInformation> ReliefInformation { get; set; }
        public virtual DbSet<RehabilitationInstitutes> RehabilitationInstitutes { get; set; }
        public virtual DbSet<GeneralUser> GeneralUser { get; set; }
    }
}
