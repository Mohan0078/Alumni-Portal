using System;
using System.Collections.Generic;

namespace EntityModels.Models
{
    public partial class Member
    {
        public Guid MemberId { get; set; }
        public Guid? ContactDetailsId { get; set; }
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ContactDetail? ContactDetails { get; set; }
    }
}
