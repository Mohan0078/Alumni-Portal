using Microsoft.EntityFrameworkCore;

namespace Alumni_Portal.Services.Utilities
{
    internal interface IUnitOfWork
    {
        Task<int> CommitTransactionAsync();
    }
}
