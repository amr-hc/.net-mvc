using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Models
{
    public class ApplicationUser : IdentityUser
    {
       public string? Address { get; set; }
    }
}
