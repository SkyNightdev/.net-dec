using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using System.Collections.Generic;
using System.Linq;

public class StudentController : Controller
{
    private static List<Student> _students = new List<Student>
    {
        new Student { Id = 1, Firstname = "Alice", Lastname = "Johnson" },
        new Student { Id = 2, Firstname = "Bob", Lastname = "Williams" }
    };

    public IActionResult Index()
    {
        return View(_students);
    }

    public IActionResult Details(int id)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Student student)
    {
        if (ModelState.IsValid)
        {
            student.Id = _students.Any() ? _students.Max(s => s.Id) + 1 : 1;
            _students.Add(student);
            return RedirectToAction(nameof(Index));
        }
        return View(student);
    }

    public IActionResult Edit(int id)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Student student)
    {
        if (ModelState.IsValid)
        {
            var existingStudent = _students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent == null)
            {
                return NotFound();
            }
            existingStudent.Firstname = student.Firstname;
            existingStudent.Lastname = student.Lastname;
            return RedirectToAction(nameof(Index));
        }
        return View(student);
    }

    public IActionResult Delete(int id)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);
        if (student != null)
        {
            _students.Remove(student);
        }
        return RedirectToAction(nameof(Index));
    }
}
