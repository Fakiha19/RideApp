﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarHailingApp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RideAppEntities : DbContext
    {
        public RideAppEntities()
            : base("name=RideAppEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblDriver> tblDrivers { get; set; }
        public virtual DbSet<tblPassenger> tblPassengers { get; set; }
        public virtual DbSet<tblRide> tblRides { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
    }
}