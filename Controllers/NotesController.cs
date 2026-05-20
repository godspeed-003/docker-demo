using Microsoft.AspNetCore.Mvc;
using DockerTestApp.Data;
using DockerTestApp.Models;

namespace DockerTestApp.Controllers
{
    public class NotesController : Controller
    {
        private readonly AppDbContext _db;
        public NotesController(AppDbContext db) { _db = db; }

        public IActionResult Index()
        {
            var list = _db.Notes.ToList();
            return View(list);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Note note)
        {
            if (!ModelState.IsValid) return View(note);
            _db.Notes.Add(note);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
