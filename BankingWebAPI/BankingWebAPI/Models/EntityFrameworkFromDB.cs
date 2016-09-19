namespace BankingWebAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class EntityFrameworkFromDB : DbContext
    {
        public EntityFrameworkFromDB()
            : base("name=EntityFrameworkFromDB")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Balance> Balances { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
