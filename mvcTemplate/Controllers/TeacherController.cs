using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace mvc.Controllers
{
    public class TeacherController : Controller
    {
        // Liste statique d'enseignants simulant une base de données
        private static List<Teacher> _teachers = new List<Teacher>
        {
            new Teacher { Id = 1, Firstname = "John", Lastname = "Doe" },
            new Teacher { Id = 2, Firstname = "Jane", Lastname = "Smith" }
        };

        // Action : Affiche la liste des enseignants
        public IActionResult Index()
        {
            return View(_teachers);
        }

        // Action : Détails d'un enseignant
        public IActionResult Details(int id)
        {
            var teacher = _teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // GET : Formulaire de création
        public IActionResult Create()
        {
            return View();
        }

        // POST : Ajout d'un nouvel enseignant
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                teacher.Id = _teachers.Any() ? _teachers.Max(t => t.Id) + 1 : 1;
                _teachers.Add(teacher);
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET : Formulaire d'édition
        public IActionResult Edit(int id)
        {
            var teacher = _teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST : Mise à jour d'un enseignant
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                var existingTeacher = _teachers.FirstOrDefault(t => t.Id == teacher.Id);
                if (existingTeacher == null)
                {
                    return NotFound();
                }
                existingTeacher.Firstname = teacher.Firstname;
                existingTeacher.Lastname = teacher.Lastname;
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET : Formulaire de suppression
        public IActionResult Delete(int id)
        {
            var teacher = _teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST : Confirmation de suppression
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var teacher = _teachers.FirstOrDefault(t => t.Id == id);
            if (teacher != null)
            {
                _teachers.Remove(teacher);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
