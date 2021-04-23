using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InteractiveSolutionsAcountManagement.Repository.Models
{
    public partial class Persons
    {
        public Persons()
        {
            Accounts = new HashSet<Accounts>();
        }

        [Key]
        [Column("code")]
        public int Code { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("surname")]
        [StringLength(50)]
        public string Surname { get; set; }
        [Required]
        [Column("id_number")]
        [StringLength(50)]
        public string IdNumber { get; set; }

        [InverseProperty("PersonCodeNavigation")]
        public virtual ICollection<Accounts> Accounts { get; set; }
    }
}
