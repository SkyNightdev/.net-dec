using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvcTemplate.Models;
using System.ComponentModel.DataAnnotations;
using mvcTemplate.Data;

namespace mvcTemplate.Data
{
    public class ApplicationDbContext : IdentityDbContext<Teacher>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet pour les tables
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Event> Events { get; set; } = null!;
    }

    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le titre est requis.")]
        [StringLength(100, ErrorMessage = "Le titre ne peut pas dépasser 100 caractères.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "La description est requise.")]
        [StringLength(500, ErrorMessage = "La description ne peut pas dépasser 500 caractères.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "La date de l'événement est requise.")]
        [Display(Name = "Date de l'événement")]
        [DataType(DataType.DateTime)]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Le nombre maximum de participants est requis.")]
        [Range(10, 200, ErrorMessage = "Le nombre de participants doit être compris entre 10 et 200.")]
        [Display(Name = "Nombre maximum de participants")]
        public int MaxParticipants { get; set; }

        [Required(ErrorMessage = "Le lieu est requis.")]
        [StringLength(100, ErrorMessage = "Le lieu ne peut pas dépasser 100 caractères.")]
        public string Location { get; set; } = string.Empty;

        [Display(Name = "Date de création")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
