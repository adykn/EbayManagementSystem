using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EMSc.Models;

namespace EMSc.Models
{
    public class _ItemsDataContext : DbContext
    {
        public _ItemsDataContext()
            : base("DefaultConnection")
        {
            
        }
        public DbSet<a_UserAAModel> UserAccessAccounts { get; set; }
        public DbSet<a_PageDefinitionModel> PageDefinition { get; set; }
        public DbSet<a_GroupPoliciesModel> GroupPolicies { get; set; }
        public DbSet<a_GroupHeadModel> GroupHead { get; set; }
        public DbSet<a_RolesModel> UserRolePolicie { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductSpecModel> ProductSpec { get; set; }
        public DbSet<ProductsVariationsModel> ProductVeriations { get; set; }
        public DbSet<PolicyModel> Policy { get; set; }
        public DbSet<ShippingModel> Shipping { get; set; }
        public DbSet<ShippingServices> ShippingServices { get; set; }
        public DbSet<ImageModel> Images { get; set; }
       

        static _ItemsDataContext()
        {
                        Database.SetInitializer(new DropCreateDatabaseIfModelChanges<_ItemsDataContext>());
            // C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}