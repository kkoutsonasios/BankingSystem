using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankingWebAPI.Models
{
    public class BankingWebAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public BankingWebAPIContext() : base("name=BankingWebAPIContext")
        {
        }

        public System.Data.Entity.DbSet<BankingWebAPI.Models.Person> People { get; set; }

        public System.Data.Entity.DbSet<BankingWebAPI.Models.Account> Accounts { get; set; }

        public System.Data.Entity.DbSet<BankingWebAPI.Models.Balance> Balances { get; set; }

        public System.Data.Entity.DbSet<BankingWebAPI.Models.Transaction> Transactions { get; set; }

        public System.Data.Entity.DbSet<BankingWebAPI.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<BankingWebAPI.Models.Setting> Settings { get; set; }
    }
}
