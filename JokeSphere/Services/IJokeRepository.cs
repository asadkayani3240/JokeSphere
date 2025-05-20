using JokeSphere.Models;

namespace JokeSphere.Services
{
    public interface IJokeRepository
    {
        Task<IList<Joke>> GetAllAsync();
        Task<Joke?> GetByIdAsync(int id);
        Task<Joke?> GetRandomAsync();
    }
}