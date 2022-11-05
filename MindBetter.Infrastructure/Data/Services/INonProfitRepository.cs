using MindBetter.Core.Model.NonProfitAggregate;

namespace MindBetter.Infrastructure.Data.Services
{
    // TODO move this to Core project
    public interface INonProfitRepository
    {
        Task<IEnumerable<NonProfit>> GetNonProfitsAsync();
        Task<NonProfit> GetNonProfitAsync(int nonProfitId);
        Task<bool> SaveChangesAsync();
        Task<bool> NonProfitExistsAsync(int nonProfitId);
    }
}
