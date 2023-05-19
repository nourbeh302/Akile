using System.ComponentModel.DataAnnotations;

namespace Akile.Models;

public class Restaurant
{
    public int Id { get; set; }
    
    [Display(Name = "Restaurant Name")]
    public required string Name { get; set; }
    public required string Category { get; set; }
    public required string Location { get; set; }
    public double Rating { get; set; }
}