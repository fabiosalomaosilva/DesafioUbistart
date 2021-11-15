using DesafioUbistart.Data;
using DesafioUbistart.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DesafioUbistart.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _db;

        public UserRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<User> Get(string email, string password)
        {
            var user = await _db.Users.Include(i => i.Role).FirstOrDefaultAsync(p => p.Email == email);
            if (user == null) 
                return null;
            if (user.Password != password.ToEncript())
                return null;

            return user;
        }

        public async Task<User> Save(string email, string password, int roleId)
        {
            var user = new User { Email = email, Password = password.ToEncript(), RoleId = roleId };
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return user;
        }
    }
}
