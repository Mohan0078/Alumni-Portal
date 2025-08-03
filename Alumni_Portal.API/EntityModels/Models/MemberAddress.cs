namespace EntityModels.Models
{
    public class MemberAddress
    {
        public Guid MemberAddressId { get; set; }
        public Guid AddressId { get; set; }
        public Guid MemberId { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
