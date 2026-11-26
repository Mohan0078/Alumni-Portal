using System;
using System.Collections.Generic;

namespace EntityModels.Models
{
    public partial class User
    {
        public User()
        {
            UserRoleAssignedByNavigations = new HashSet<UserRole>();
            UserRoleUsers = new HashSet<UserRole>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string Password { get; set; } = null!;
        public string? ProfileImage { get; set; }
        public DateTime? EmailVerifiedAt { get; set; }
        public string? Status { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<UserRole> UserRoleAssignedByNavigations { get; set; }
        public virtual ICollection<UserRole> UserRoleUsers { get; set; }
    }
}
