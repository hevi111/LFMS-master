﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LFMS.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class lfmsdb_ModelEntities : DbContext
    {
        public lfmsdb_ModelEntities()
            : base("name=lfmsdb_ModelEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<department> departments { get; set; }
        public virtual DbSet<FoundItem> FoundItems { get; set; }
        public virtual DbSet<LostItem> LostItems { get; set; }
        public virtual DbSet<useraccount> useraccounts { get; set; }
    }
}
