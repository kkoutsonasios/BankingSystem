namespace BankingWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transaction")]
    public partial class Transaction
    {
        public long Id { get; set; }

        public double Amount { get; set; }

        [Required]
        [StringLength(150)]
        public string Description { get; set; }

        public long PersonId { get; set; }

        public long AccountId { get; set; }

        public bool Executed { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ExecutionDate { get; set; }

        public virtual Account Account { get; set; }

        public virtual Person Person { get; set; }
    }
}
