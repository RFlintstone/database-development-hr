using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models;

public class Project
{
    [Required]
    [MaxLength(15)]
    public string Pname { get; set; } = String.Empty;

    [Key]
    public int Pnumber { get; set; }

    [MaxLength(15)]
    public string? Plocation { get; set; }

    [ForeignKey(nameof(Department))]
    public int Dnum { get; set; }

    // Navigation property
    public Department? Department { get; set; }
}