using Microsoft.EntityFrameworkCore;

namespace Alumni_Portal.Services.Utilities
{
    internal interface IUnitOfWork<out TContext> where TContext : DbContext, new()
    {
        TContext Context { get; }
    }
}
