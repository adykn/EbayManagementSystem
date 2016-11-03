using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EMSc.Models;

namespace EMSc.Models
{
    public class ItemsDataContext : DbContext
    {
        public ItemsDataContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<a_siteaccessModel> a_siteaccess { get; set; }
        public DbSet<a_siteaccesslistModel> a_siteaccesslist { get; set; }
        public DbSet<a_pageinfoModel> a_pageinfo { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<PolicyModel> Policy { get; set; }
        public DbSet<ShippingModel> Shipping { get; set; }
        public DbSet<ShippingServices> ShippingServices { get; set; }
        public DbSet<ImageModel> Images { get; set; }
       

        static ItemsDataContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ItemsDataContext>());
        }

    }
}