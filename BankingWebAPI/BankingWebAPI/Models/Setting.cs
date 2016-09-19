namespace BankingWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Setting
    {
        public long Id { get; set; }

        [Key]
        [StringLength(50)]
        public string SettingName { get; set; }

        [StringLength(250)]
        public string SettingValueStr { get; set; }

        public bool? SettingValueBool { get; set; }

        public double? SettingValueNumber { get; set; }
    }
}
