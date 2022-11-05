using Microsoft.EntityFrameworkCore;
using MindBetter.Core.Model.NonProfitAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBetter.Infrastructure.Data.Services
{
    public class NonProfitRepository : INonProfitRepository
    {
        private readonly AppDbContext _context;
        public NonProfitRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public async Task<bool> NonProfitExistsAsync(int nonProfitId)
        {
            return await _context.NonProfits.AnyAsync(np => np.Id == nonProfitId);
        }

        public async Task<NonProfit> GetNonProfitAsync(int nonProfitId)
        {
            return await _context.NonProfits.Include(np => np.Members).Include(np => np.Services).FirstOrDefaultAsync(np => np.Id == nonProfitId);
        }

        public async Task<IEnumerable<NonProfit>> GetNonProfitsAsync()
        {
            return await _context.NonProfits.Include(np => np.Services).ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
