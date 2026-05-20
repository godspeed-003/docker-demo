using Microsoft.AspNetCore.Mvc;
using DockerTestApp.Data;
using DockerTestApp.Models;

namespace DockerTestApp.Controllers
{
    public class PeopleController : Controller
    {
        private readonly AppDbContext _db;
        public PeopleController(AppDbContext db) { _db = db; }

        public IActionResult Index()
        {
            var list = _db.People.ToList();
            return View(list);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Person person)
        {
            if (!ModelState.IsValid) return View(person);
            _db.People.Add(person);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
