using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InteractiveSolutionsAcountManagement.Repository.Models
{
    public partial class Transactions
    {
        [Key]
        [Column("code")]
        public int Code { get; set; }
        [Column("account_code")]
        public int AccountCode { get; set; }
        [Column("transaction_date", TypeName = "datetime")]
        public DateTime TransactionDate { get; set; }
        [Column("capture_date", TypeName = "datetime")]
        public DateTime CaptureDate { get; set; }
        [Column("amount", TypeName = "money")]
        public decimal Amount { get; set; }
        [Required]
        [Column("description")]
        [StringLength(100)]
        public string Description { get; set; }

        [ForeignKey(nameof(AccountCode))]
        [InverseProperty(nameof(Accounts.Transactions))]
        public virtual Accounts AccountCodeNavigation { get; set; }
    }
}
