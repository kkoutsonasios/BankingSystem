//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BankingWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Balance
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public double Amount { get; set; }
    
        public virtual Account Account { get; set; }
    }
}
