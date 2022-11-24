using MindBetter.Core.Model;

namespace MindBetter.Infrastructure.Data.Services
{
    // TODO move this to Core Project
    public interface IUserRepository
    {
        Task<User> ValidateUserCredentials(string userName, byte[] password, byte[] passwordSalt);

    }
}
