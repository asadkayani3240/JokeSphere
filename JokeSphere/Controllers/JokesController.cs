using JokeSphere.Models;
using JokeSphere.Services;
using Microsoft.AspNetCore.Mvc;

namespace JokeSphere.Controllers
{
    public class JokesController : Controller
    {
        private readonly IJokeRepository _repo;
        public JokesController(IJokeRepository repo) => _repo = repo;

        // GET: /Jokes
        public async Task<IActionResult> Index()
        {
            var all = await _repo.GetAllAsync();
            return View(all);
        }

        // GET: /Jokes/Random
        public async Task<IActionResult> Random()
        {
            var joke = await _repo.GetRandomAsync();
            if (joke == null) return NotFound();
            return View(joke);
        }

        // GET: /Jokes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var joke = await _repo.GetByIdAsync(id);
            if (joke == null) return NotFound();
            return View(joke);
        }
    }
}