using Microsoft.AspNetCore.Identity;

namespace Akile.Identity.Data;

class User : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Zone { get; set; }
}