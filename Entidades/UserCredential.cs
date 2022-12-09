using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ApiCompraventa.Entidades
{
    public class UserCredential : IdentityUser
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

    }
}