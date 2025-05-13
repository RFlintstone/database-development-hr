using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models;

public class WorksOn
{
    [Key, Column(Order = 0)]
    [ForeignKey(nameof(Employee))]
    public string Essn { get; set; } = String.Empty;

    [Key, Column(Order = 1)]
    [ForeignKey(nameof(Project))]
    public int Pno { get; set; }

    [Column(TypeName = "decimal(3,1)")]
    public decimal Hours { get; set; }

    // Navigation properties
    public Employee? Employee { get; set; }
    public Project? Project { get; set; }
}