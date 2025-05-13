using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models;

public class Employee
{
    [Required]
    [MaxLength(15)]
    public string Fname { get; set; } = null!;

    [MaxLength(1)]
    public string? Minit { get; set; }

    [Required]
    [MaxLength(15)]
    public string Lname { get; set; } = null!;

    [Key]
    [StringLength(9)] // For CHAR(9)
    public string Ssn { get; set; } = null!;

    public DateTime? Bdate { get; set; }

    [MaxLength(50)]
    public string? Address { get; set; }

    [MaxLength(1)]
    public string? Sex { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Salary { get; set; }

    [ForeignKey(nameof(Supervisor))]
    [StringLength(9)]
    public string? Super_ssn { get; set; }

    public Employee? Supervisor { get; set; }

    [Required]
    public int Dno { get; set; }
}