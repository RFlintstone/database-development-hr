using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models;

public class Dependent
{
    [Key, Column(Order = 0)]
    [ForeignKey(nameof(Employee))]
    public string Essn { get; set; } = String.Empty;

    [Key, Column(Order = 1)]
    public string Dependent_name { get; set; } = String.Empty;

    public string Sex { get; set; } = String.Empty;

    public DateTime Bdate { get; set; }

    public string Relationship { get; set; } = String.Empty;

    // Navigation
    public Employee? Employee { get; set; }
}