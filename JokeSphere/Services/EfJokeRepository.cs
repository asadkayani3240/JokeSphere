using JokeSphere.Data;
using JokeSphere.Models;
using Microsoft.EntityFrameworkCore;

namespace JokeSphere.Services
{
    public class EfJokeRepository : IJokeRepository
    {
        private readonly ApplicationDbContext _db;

        public EfJokeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IList<Joke>> GetAllAsync() =>
            await _db.Jokes.ToListAsync();

        public async Task<Joke?> GetByIdAsync(int id) =>
            await _db.Jokes.FindAsync(id);

        public async Task<Joke?> GetRandomAsync()
        {
            var count = await _db.Jokes.CountAsync();
            if (count == 0) return null;
            var skip = new Random().Next(count);
            return await _db.Jokes
                .Skip(skip)
                .FirstOrDefaultAsync();
        }
    }
}