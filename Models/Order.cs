using System.ComponentModel.DataAnnotations;

namespace Akile.Models;

public class Order
{
    public int Id { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime CreatedAt { get; set; }
    public State State { get; set; }
    public int Quantity { get; set; }
}

public enum State
{
    Pending,
    Cancelled,
    Delivered
}