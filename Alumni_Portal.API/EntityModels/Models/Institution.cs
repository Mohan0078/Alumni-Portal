using System;
using System.Collections.Generic;

namespace EntityModels.Models
{
    public partial class Institution
    {
        public Institution()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Logo { get; set; }
        public int? EstablishedYear { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
