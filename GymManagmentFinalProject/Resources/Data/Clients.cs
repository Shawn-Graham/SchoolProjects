using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Clients
{
    [Key]
    public int MemberId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int Age { get; set; }
    public string MembershipType { get; set; } = "Silver";
    public string MembershipStatus { get; set; } = "Active";
    public int? AssignedEmployeeId { get; set; }
}
