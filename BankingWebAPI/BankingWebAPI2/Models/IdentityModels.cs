using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace BankingWebAPI2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("BankDBEntities", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<BankingWebAPI2.Models.Person> People { get; set; }

        public System.Data.Entity.DbSet<BankingWebAPI2.Models.Account> Accounts { get; set; }

        public System.Data.Entity.DbSet<BankingWebAPI2.Models.Balance> Balances { get; set; }

        public System.Data.Entity.DbSet<BankingWebAPI2.Models.Setting> Settings { get; set; }

        public System.Data.Entity.DbSet<BankingWebAPI2.Models.Transaction> Transactions { get; set; }

        public System.Data.Entity.DbSet<BankingWebAPI2.Models.eUser> eUsers { get; set; }
    }
}