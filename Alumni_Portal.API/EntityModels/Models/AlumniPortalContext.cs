using Microsoft.EntityFrameworkCore;

namespace EntityModels.Models
{
    public class AlumniPortalContext : DbContext
    {
        public AlumniPortalContext(DbContextOptions<AlumniPortalContext> options) : base(options)
        {
        }
        public DbSet<Address> Addresses;
        public DbSet<ContactDetails> ContactDetails;
        //public DbSet<LoginDetails> LoginDetails;
        public DbSet<Member> Members;
        public DbSet<MemberAddress> MemberAddresses;
    }
}
