using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InteractiveSolutionsAcountManagement.Repository.Models
{
    public partial class Accounts
    {
        public Accounts()
        {
            Transactions = new HashSet<Transactions>();
        }

        [Key]
        [Column("code")]
        public int Code { get; set; }
        [Column("person_code")]
        public int PersonCode { get; set; }
        [Required]
        [Column("account_number")]
        [StringLength(50)]
        public string AccountNumber { get; set; }
        [Column("outstanding_balance", TypeName = "money")]
        public decimal OutstandingBalance { get; set; }

        [ForeignKey(nameof(PersonCode))]
        [InverseProperty(nameof(Persons.Accounts))]
        public virtual Persons PersonCodeNavigation { get; set; }
        [InverseProperty("AccountCodeNavigation")]
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
