namespace EntityModels.Models
{
    public class MemberRole
    {
        public Guid MemberRoleId { get; set; }
        public Guid MemberId { get; set; }
        public Guid RoleId { get; set; }
        public virtual Member? Member { get; set; }
        public virtual Role? Role { get; set; }
    }
}
