using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace prototype2.Resources.Data
{
    [Table("Equipment")]
    public class Equipment
    {
        [Key]
        [Column("equipment_id")]
        public int EquipmentId { get; set; }

        [Column("category_id")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Column("name")]
        [StringLength(100)]
        public string? Name { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("daily_rate")]
        public decimal DailyRate { get; set; }

        // Navigation properties
        public virtual Category? Category { get; set; }
        public virtual ICollection<Rental>? Rentals { get; set; }
    }

}
