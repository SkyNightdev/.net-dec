using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace mvcTemplate.Models
{
    public class Teacher : IdentityUser
    {
        [Required(ErrorMessage = "Le prénom est requis.")]
        [StringLength(50)]
        public string Firstname { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le nom est requis.")]
        [StringLength(50)]
        public string Lastname { get; set; } = string.Empty;

        [Url(ErrorMessage = "URL invalide.")]
        public string PersonalWebSite { get; set; } = string.Empty;
    }
}
