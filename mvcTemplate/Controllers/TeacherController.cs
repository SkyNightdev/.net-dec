using Microsoft.AspNetCore.Mvc;
using mvcTemplate.Data;
using mvcTemplate.Models;

namespace mvcTemplate.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var teachers = _context.Teachers.ToList(); // Récupère les enseignants depuis la BDD
            return View(teachers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Teachers.Add(teacher); // Ajoute un enseignant dans la BDD
                _context.SaveChanges(); // Enregistre les modifications
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        [HttpPost]
        public IActionResult Edit(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Teachers.Update(teacher); // Met à jour l'enseignant
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.Id == id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher); // Supprime l'enseignant
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Students(string id)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            var students = _context.Students.Where(s => s.TeacherId == id).ToList();
            ViewBag.TeacherName = $"{teacher.Firstname} {teacher.Lastname}";
            return View(students);
        }
    }
}
