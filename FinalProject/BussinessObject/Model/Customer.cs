using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BussinessObject.Model
{
    public class Customer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(30)]
        public string ContactName { get; set; }
        [Required]
        [StringLength(30)]
        public string ContactTitle { get; set; }
        [Required]
        [StringLength(60)]
        public string Address { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
