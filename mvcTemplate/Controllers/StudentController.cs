using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvcTemplate.Models;
using mvcTemplate.Data;

namespace mvcTemplate.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Inclut l'enseignant associé à chaque étudiant
            var students = _context.Students.Include(s => s.Teacher).ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult Add()
        {
            // Passe la liste des enseignants à la vue
            ViewBag.Teachers = _context.Teachers.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Teachers = _context.Teachers.ToList();
            return View(student);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            ViewBag.Teachers = _context.Teachers.ToList();
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Teachers = _context.Teachers.ToList();
            return View(student);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
