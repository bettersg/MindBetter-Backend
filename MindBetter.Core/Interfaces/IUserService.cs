using MindBetter.Core.Model;

namespace MindBetter.Core.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
    }
}
