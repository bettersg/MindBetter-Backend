using Microsoft.EntityFrameworkCore;
using MindBetter.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBetter.Infrastructure.Data.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public async Task<User> ValidateUserCredentials(string userName, byte[] password, byte[] passwordSalt)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }
    }
}
