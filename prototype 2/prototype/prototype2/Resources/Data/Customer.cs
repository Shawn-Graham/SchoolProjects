
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prototype2.Resources.Data
{
   

    // Customer Class
    [Table("Customers")]
    public class Customer
    {
        [Key]
        [Column("customer_id")]
        public int CustomerId { get; set; }

        [Column("last_name")]
        [StringLength(50)]
        public string? LastName { get; set; }

        [Column("first_name")]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Column("contact_phone")]
        [StringLength(20)]
        public string? ContactPhone { get; set; }

        [Column("email")]
        [StringLength(100)]
        public string? Email { get; set; }

        // Navigation property for rentals
        public virtual ICollection<Rental>? Rentals { get; set; }

        // Computed property for full name
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}".Trim();

    }
   

}