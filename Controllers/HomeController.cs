using Microsoft.AspNetCore.Mvc;
using DockerTestApp.Data;
using DockerTestApp.Models;

namespace DockerTestApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "People");
        }

        public IActionResult Error() => View();

        // GET /Home/Seed
        // Seeds a couple of sample rows (safe for local dev).
        public IActionResult Seed()
        {
            try
            {
                using var scope = HttpContext.RequestServices.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var addedPeople = 0;
                if (!db.People.Any(p => p.Email == "alice@example.com"))
                {
                    db.People.Add(new Person { Name = "Alice Tester", Email = "alice@example.com" });
                    addedPeople++;
                }
                if (!db.People.Any(p => p.Email == "bob@example.com"))
                {
                    db.People.Add(new Person { Name = "Bob Example", Email = "bob@example.com" });
                    addedPeople++;
                }

                var addedNotes = 0;
                if (!db.Notes.Any(n => n.Title == "Hello"))
                {
                    db.Notes.Add(new Note { Title = "Hello", Content = "Seeded note" });
                    addedNotes++;
                }
                if (!db.Notes.Any(n => n.Title == "Welcome"))
                {
                    db.Notes.Add(new Note { Title = "Welcome", Content = "Another seeded note" });
                    addedNotes++;
                }

                db.SaveChanges();

                return Content($"Seeded: People={addedPeople}, Notes={addedNotes}");
            }
            catch (Exception ex)
            {
                return Content("Seeding failed: " + ex.Message);
            }
        }

        // GET /Home/SeedIndia
        // Seeds several Indian sample rows (idempotent).
        public IActionResult SeedIndia()
        {
            try
            {
                using var scope = HttpContext.RequestServices.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var indianPeople = new[] {
                    new { Name = "Aarav Kumar", Email = "aarav.kumar@example.in" },
                    new { Name = "Saanvi Sharma", Email = "saanvi.sharma@example.in" },
                    new { Name = "Vihaan Singh", Email = "vihaan.singh@example.in" },
                    new { Name = "Ananya Patel", Email = "ananya.patel@example.in" },
                    new { Name = "Arjun Rao", Email = "arjun.rao@example.in" },
                    new { Name = "Ishita Gupta", Email = "ishita.gupta@example.in" },
                    new { Name = "Rohan Mehta", Email = "rohan.mehta@example.in" },
                    new { Name = "Priya Nair", Email = "priya.nair@example.in" },
                    new { Name = "Karan Kapoor", Email = "karan.kapoor@example.in" },
                    new { Name = "Neha Joshi", Email = "neha.joshi@example.in" }
                };

                var addedPeople = 0;
                foreach (var p in indianPeople)
                {
                    if (!db.People.Any(x => x.Email == p.Email))
                    {
                        db.People.Add(new Person { Name = p.Name, Email = p.Email });
                        addedPeople++;
                    }
                }

                var indianNotes = new[] {
                    new { Title = "Diwali Wishes", Content = "Wishing you a very Happy Diwali!" },
                    new { Title = "Holi Colors", Content = "Enjoy the festival of colors." },
                    new { Title = "Ganesh Chaturthi", Content = "Celebrate with sweets and family." },
                    new { Title = "Independence Day", Content = "Proud to be Indian." },
                    new { Title = "Republic Day", Content = "Salute the nation." },
                    new { Title = "Raksha Bandhan", Content = "Siblings' bond celebration." },
                    new { Title = "Navratri", Content = "Nine nights of dance and devotion." },
                    new { Title = "Pongal", Content = "Harvest festival wishes." },
                    new { Title = "Baisakhi", Content = "Happy Baisakhi to all." },
                    new { Title = "Onam", Content = "Celebrate the spirit of Kerala." }
                };

                var addedNotes = 0;
                foreach (var n in indianNotes)
                {
                    if (!db.Notes.Any(x => x.Title == n.Title))
                    {
                        db.Notes.Add(new Note { Title = n.Title, Content = n.Content });
                        addedNotes++;
                    }
                }

                db.SaveChanges();
                return Content($"Seeded India: People={addedPeople}, Notes={addedNotes}");
            }
            catch (Exception ex)
            {
                return Content("Seeding failed: " + ex.Message);
            }
        }
    }
}
