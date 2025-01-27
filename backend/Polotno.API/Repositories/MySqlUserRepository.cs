using Microsoft.EntityFrameworkCore;
using Polotno.API.Models;

namespace Polotno.API.Repositories
{
    public class MySqlUserRepository : IUserRepository
    {
        private readonly PolotnoContext dbcontext;

        public MySqlUserRepository(PolotnoContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<User> AddAsync(User user)
        {
            await dbcontext.Users.AddAsync(user);
            await dbcontext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> DeleteAsync(int id)
        {
            var existingUser = await dbcontext.Users.FirstOrDefaultAsync(x => x.UserId == id);

            if (existingUser == null){
                return null;
            }
            
            dbcontext.Users.Remove(existingUser);
            await dbcontext.SaveChangesAsync();
            return existingUser;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var user = await dbcontext.Users.FirstOrDefaultAsync(x => x.UserId == id);
            return user;
        }

        public async Task<User?> UpdateAsync(User user)
        {
            var existingUser = await dbcontext.Users.FirstOrDefaultAsync(x => x.UserId == user.UserId);

            if (existingUser == null){
                return null;
            }

            existingUser.Username = user.Username;
            existingUser.PasswordHash = user.PasswordHash;
            existingUser.Email = user.Email;
            await dbcontext.SaveChangesAsync();

            return user;
        }
    }
}