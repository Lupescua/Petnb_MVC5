using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;using Petnb_MVC5.Models;

namespace Petnb_MVC5.DAL
{
    public class DatabaseContext : DbContext    {
        public DatabaseContext() : base("DatabaseContext")
        {
            Database.SetInitializer<DatabaseContext>(null); // Remove default initializer
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }   

        public DbSet<OwnerUser> OwnerUser { get; set; }
        public DbSet<SitterUser> SitterUser { get; set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<PetOffer> PetOffer { get; set; }
        public DbSet<PetSitterOffer> PetSitterOffer { get; set; }
        public DbSet<Review> Review { get; set; }


        public static DatabaseContext Create()
        {
            return new DatabaseContext();
        }

      

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // IMPORTANT: we are mapping the entity User to the same table as the entity ApplicationUser
            modelBuilder.Entity<OwnerUser>().ToTable("OwnerUser");
            modelBuilder.Entity<SitterUser>().ToTable("SitterUser");
       
        }
    }

}