using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class Role : IdentityRole
    {
        public Role() : base()
        {
        }
        public Role(string roleName) : base(roleName)
        {
        }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
