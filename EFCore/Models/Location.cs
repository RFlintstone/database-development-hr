using System.ComponentModel.DataAnnotations;

namespace EFCore.Models;

public class Location
{
    [Key]
    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;
}