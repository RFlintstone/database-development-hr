using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models;

public class DeptLocations
{
    [Key, Column(Order = 0)]
    public int Dnumber { get; set; }

    [Key, Column(Order = 1)]
    [MaxLength(50)]
    public string Dlocation { get; set; } = null!;

    // Navigation properties (optional but useful)
    public Department? Department { get; set; }
    public Location? Location { get; set; }
}