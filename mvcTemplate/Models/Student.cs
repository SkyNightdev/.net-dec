using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcTemplate.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le prénom est requis.")]
        [StringLength(50, ErrorMessage = "Le prénom ne peut pas dépasser 50 caractères.")]
        public string Firstname { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le nom est requis.")]
        [StringLength(50, ErrorMessage = "Le nom ne peut pas dépasser 50 caractères.")]
        public string Lastname { get; set; } = string.Empty;

        [Range(1, 150, ErrorMessage = "L'âge doit être compris entre 1 et 150.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "La date d'admission est requise.")]
        [DataType(DataType.Date, ErrorMessage = "Format de date invalide.")]
        public DateTime AdmissionDate { get; set; }

        [Range(0, 4, ErrorMessage = "Le GPA doit être compris entre 0 et 4.")]
        public double GPA { get; set; }

        [StringLength(100, ErrorMessage = "La spécialisation ne peut pas dépasser 100 caractères.")]
        public string Major { get; set; } = string.Empty;

        // Foreign key for Teacher
        [Required(ErrorMessage = "Un enseignant est requis.")]
        public string TeacherId { get; set; } = string.Empty;

        // Navigation property for the associated Teacher
        [ForeignKey("TeacherId")]
        public Teacher? Teacher { get; set; } // Propriété de navigation pour la relation avec Teacher
    }
}
