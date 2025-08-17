using Microsoft.EntityFrameworkCore;

namespace EntityModels.Models
{
    public class AlumniPortalContext : DbContext
    {
        public AlumniPortalContext(DbContextOptions<AlumniPortalContext> options) : base(options)
        {
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
        //public DbSet<LoginDetails> LoginDetails;
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberAddress> MemberAddresses { get; set; }
    }
}
