using System;
using System.Collections.Generic;

namespace EntityModels.Models
{
    public partial class ContactDetail
    {
        public ContactDetail()
        {
            Members = new HashSet<Member>();
        }

        public Guid ContactDetailsId { get; set; }
        public string Email { get; set; } = null!;
        public string MobileNumber { get; set; } = null!;
        public string SocialMediaType { get; set; } = null!;
        public string SocialMediaUrl { get; set; } = null!;
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
