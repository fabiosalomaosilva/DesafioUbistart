using DesafioUbistart.Data;
using DesafioUbistart.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DesafioUbistart.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly DataContext _db;

        public RefreshTokenRepository(DataContext db)
        {
            _db = db;
        }
        public async Task Save(RefreshToken token)
        {
            _db.RefreshTokens.Add(token);
            await _db.SaveChangesAsync();
        }

        public async Task<string> GetByEmail(string email)
        {
            return (await _db.RefreshTokens.FirstOrDefaultAsync(p => p.Email == email)).Token;
        }

        public async Task<bool> ExistsToken(string token)
        {
            return (await _db.RefreshTokens.AnyAsync(p => p.Token == token));
        }

        public async Task Delete(string token)
        {
            var obj = await _db.RefreshTokens.FirstOrDefaultAsync(p => p.Token == token);
            _db.RefreshTokens.Remove(obj);
            await _db.SaveChangesAsync();
        }
    }
}
