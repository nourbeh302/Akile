using System.ComponentModel.DataAnnotations;

namespace Akile.Models;

public class Item
{
    public int Id { get; set; }

    [Display(Name = "Item Name")]
    public required string? Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }

    public virtual Restaurant? Restaurant { get; set; }
}