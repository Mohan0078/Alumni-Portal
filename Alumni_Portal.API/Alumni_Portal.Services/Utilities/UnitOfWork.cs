using EntityModels.Models;

namespace Alumni_Portal.Services.Utilities
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AlumniPortalContext _alumniPortalContext;

        public UnitOfWork(AlumniPortalContext alumniPortalContext)
        {
            _alumniPortalContext = alumniPortalContext;
        }

        public Task<int> CommitTransactionAsync()
        {
            return _alumniPortalContext.SaveChangesAsync();
        }
    }
}
