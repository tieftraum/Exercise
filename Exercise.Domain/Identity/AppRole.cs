using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Exercise.Domain.Identity
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}