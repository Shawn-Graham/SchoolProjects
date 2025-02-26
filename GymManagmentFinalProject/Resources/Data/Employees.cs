using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagmentFinalProject.Resources.Data
{
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Wage { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateHired { get; set; }
        public DateTime? DateFired { get; set; }
        public string JobTitle { get; set; }
        public string Password { get; set; }
    }
}
