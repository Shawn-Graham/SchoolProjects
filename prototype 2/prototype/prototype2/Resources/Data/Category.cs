using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prototype2.Resources.Data
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [Column("category_id")]
        public int CategoryId { get; set; }

        [Column("name")]
        [StringLength(100)]
        public string? Name { get; set; }

        // Navigation property for related equipment
        public virtual ICollection<Equipment>? Equipment { get; set; }
    }

}
