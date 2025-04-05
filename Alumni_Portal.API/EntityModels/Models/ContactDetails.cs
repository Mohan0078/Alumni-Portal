namespace EntityModels.Models
{
    public class ContactDetails
    {
        public Guid ContactDetailsId { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string SocialMediaType { get; set; }
        public string SocialMediaURL { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? LastUpdatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
    }
}
