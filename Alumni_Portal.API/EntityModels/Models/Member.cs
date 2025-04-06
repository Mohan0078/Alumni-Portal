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
        public Guid? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public virtual ContactDetails ContactDetails { get; set; }
    }
}
