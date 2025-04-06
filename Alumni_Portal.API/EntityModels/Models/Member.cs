namespace EntityModels.Models
{
    public class Member
    {
        public Guid MemberId { get; set; }
        public Guid? ContactDetailsId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public virtual ContactDetails ContactDetails { get; set; }
    }
}
