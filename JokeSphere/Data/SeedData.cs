using JokeSphere.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace JokeSphere.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await context.Database.MigrateAsync();

            if (await context.Jokes.AnyAsync())
                return;

            // Load jokes.json from wwwroot/data
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/data/jokes.json");
            var json = await File.ReadAllTextAsync(path);
             // After deserializing:
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var jokes = JsonSerializer.Deserialize<List<Joke>>(json, options);

            if (jokes is not null)
            {
                // Reset Id on each so SQL Server will generate its own
                foreach (var joke in jokes)
                {
                    joke.Id = 0;
                }

                await context.Jokes.AddRangeAsync(jokes);
                await context.SaveChangesAsync();
            }
        }
    }
}