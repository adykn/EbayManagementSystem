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

            var emp = new a_UserAAModel();
            emp.Email = "4d.kh4n@gmail.com";
            emp.Name = "Adnan khan";
            emp.Password = "test";
            emp.Picfid = 0;
            emp.Contact = "03339323452";
           
            UserAccessAccounts.Add(emp);
            SaveChanges();
            

        }
        public DbSet<a_UserAAModel> UserAccessAccounts { get; set; }
        public DbSet<a_PageDefinitionModel> PageDefinition { get; set; }
        public DbSet<a_GroupPoliciesModel> GroupPolicies { get; set; }
        public DbSet<a_UserRolesModel> UserRolePolicie { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductSpecModel> ProductSpec { get; set; }
        public DbSet<ProductsVariationsModel> ProductVeriations { get; set; }
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