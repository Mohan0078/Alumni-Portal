namespace EntityModels.Models
{
    internal class LoginDetail
    {
      public Guid LoginDetailId { get; set; }
      public Guid MemberId { get; set; }
      public string LoginEmail { get; set; }
      public string Password { get; set; }
      public virtual Member Member { get; set; }
    }
}
