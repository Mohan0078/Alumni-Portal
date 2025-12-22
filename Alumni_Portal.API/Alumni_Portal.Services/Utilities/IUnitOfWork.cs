using Microsoft.EntityFrameworkCore;

namespace Alumni_Portal.Services.Utilities
{
    public interface IUnitOfWork
    {
        Task<int> CommitTransactionAsync();
    }
}
