using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prototype2.Resources.Data
{
    [Table("Rentals")]
    public class Rental
    {
        [Key]
        [Column("rental_id")]
        public int RentalId { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("customer_id")]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [Column("equipment_id")]
        [ForeignKey("Equipment")]
        public int EquipmentId { get; set; }

        [Column("rental_date")]
        public DateTime RentalDate { get; set; }

        [Column("return_date")]
        public DateTime? ReturnDate { get; set; }

        [Column("cost")]
        public decimal Cost { get; set; }

        // Navigation properties
        public virtual Customer? Customer { get; set; }
        public virtual Equipment? Equipment { get; set; }
    }

}
