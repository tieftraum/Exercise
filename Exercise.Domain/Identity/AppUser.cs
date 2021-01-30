using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Exercise.Domain.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string Gender { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}