using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using Petnb_MVC5.Models.Enums;

namespace Petnb_MVC5.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string FullName { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public double? Rating { get; set; }
        public string Address { get; set; }
        public int? Age { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("Pet2", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }
       
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Petnb_MVC5.Models.OwnerUser> OwnerUsers { get; set; }

        public System.Data.Entity.DbSet<Petnb_MVC5.Models.SitterUser> SitterUsers { get; set; }
        
        public System.Data.Entity.DbSet<Petnb_MVC5.Models.Pet> Pets { get; set; }

        public System.Data.Entity.DbSet<Petnb_MVC5.Models.Review> Reviews { get; set; }

        public System.Data.Entity.DbSet<Petnb_MVC5.Models.PetOffer> PetOffers { get; set; }

        public System.Data.Entity.DbSet<Petnb_MVC5.Models.PetSitterOffer> PetSitterOffers { get; set; }
    }
}