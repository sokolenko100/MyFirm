﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyFirm.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MyFirmEntiti : DbContext
    {
        public MyFirmEntiti()
            : base("name=MyFirmEntiti")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Customers> Customers { get; set; }
        public DbSet<CustomersOrders> CustomersOrders { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrdersProducts> OrdersProducts { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
    }
}