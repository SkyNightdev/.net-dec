using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvcTemplate.Models;
using mvcTemplate.Data;

namespace mvcTemplate.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Affiche la liste des événements
        public IActionResult Index()
        {
            try
            {
                // Inclure les enseignants liés aux événements
                var events = _context.Events.Include(e => e.Teacher).ToList();
                return View(events);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Erreur lors du chargement des événements.";
                Console.WriteLine(ex.Message);
                return View(new List<Event>());
            }
        }

        // Formulaire d'ajout d'un événement (GET)
        [HttpGet]
        public IActionResult Add()
        {
            try
            {
                ViewBag.Teachers = _context.Teachers.ToList();
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Erreur lors du chargement des enseignants.";
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }
        }

        // Ajout d'un événement (POST)
        [HttpPost]
        public IActionResult Add(Event eventModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Teachers = _context.Teachers.ToList();
                return View(eventModel);
            }

            try
            {
                _context.Events.Add(eventModel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Erreur lors de l'ajout de l'événement.";
                Console.WriteLine(ex.Message);
                ViewBag.Teachers = _context.Teachers.ToList();
                return View(eventModel);
            }
        }

        // Formulaire de modification d'un événement (GET)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                var eventModel = _context.Events.Include(e => e.Teacher).FirstOrDefault(e => e.Id == id);
                if (eventModel == null)
                {
                    return NotFound("Événement introuvable.");
                }

                ViewBag.Teachers = _context.Teachers.ToList();
                return View(eventModel);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Erreur lors du chargement de l'événement.";
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }
        }

        // Modification d'un événement (POST)
        [HttpPost]
        public IActionResult Edit(Event eventModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Teachers = _context.Teachers.ToList();
                return View(eventModel);
            }

            try
            {
                _context.Events.Update(eventModel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Erreur lors de la modification de l'événement.";
                Console.WriteLine(ex.Message);
                ViewBag.Teachers = _context.Teachers.ToList();
                return View(eventModel);
            }
        }

        // Formulaire de suppression d'un événement (GET)
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var eventModel = _context.Events.Include(e => e.Teacher).FirstOrDefault(e => e.Id == id);
                if (eventModel == null)
                {
                    return NotFound("Événement introuvable.");
                }

                return View(eventModel);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Erreur lors du chargement de l'événement.";
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }
        }

        // Suppression d'un événement (POST)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var eventModel = _context.Events.FirstOrDefault(e => e.Id == id);
                if (eventModel != null)
                {
                    _context.Events.Remove(eventModel);
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Erreur lors de la suppression de l'événement.";
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }
        }
    }
}
