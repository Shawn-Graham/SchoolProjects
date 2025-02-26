using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class EquipmentList
{
    [Key]
    public int EquipmentId { get; set; }
    public string? EquipmentType { get; set; }
    public string? EquipmentName { get; set; }
    public int? YearMade { get; set; }
    public int? YearPurchased { get; set; }
    public string? InUse { get; set; }
    public int? AssignedToEmployeeId { get; set; }
}
