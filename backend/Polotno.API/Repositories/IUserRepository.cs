using Polotno.API.Models;

namespace Polotno.API.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<User> AddAsync(User user);
        Task<User?> UpdateAsync(User user);
        Task<User?> DeleteAsync(int id);
    }
}