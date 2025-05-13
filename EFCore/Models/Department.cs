using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models;

public class Department
{
    [Required]
    [MaxLength(15)]
    public string Dname { get; set; } = String.Empty;

    [Key]
    public int Dnumber { get; set; }

    [StringLength(9)]
    [ForeignKey(nameof(Manager))]
    public string? Mgr_ssn { get; set; }

    public DateTime? Mgr_start_date { get; set; }

    public Employee? Manager { get; set; }
}