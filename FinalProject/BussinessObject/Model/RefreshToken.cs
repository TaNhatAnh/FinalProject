using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Model
{
    public class RefreshToken
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int AccountId { get; set; }
        [StringLength(25)]
        public string TokenId { get; set; } = null!;
        [StringLength(100)]
        public string Token { get; set; } = null!;
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public DateTime Expires { get; set; }

        public virtual Account Account { get; set; } = null!;
    }
}
