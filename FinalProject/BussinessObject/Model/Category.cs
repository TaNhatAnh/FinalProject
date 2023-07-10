using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BussinessObject.Model
{
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }
        [Required]
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        [Required]
        [StringLength(55)]
        public string CategoryGeneral { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
