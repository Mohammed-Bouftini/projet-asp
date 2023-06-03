using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace projet_asp.Models
{
    public class Directeur
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceName = "nomErr", ErrorMessageResourceType = typeof(Resources.ModelsResources.Directeur.ResourceDirecteur))]
        [Display(Name = "nom", ResourceType = typeof(Resources.ModelsResources.Directeur.ResourceDirecteur))]
        public string Nom { get; set; }

        [Required(ErrorMessageResourceName = "prenomErr", ErrorMessageResourceType = typeof(Resources.ModelsResources.Directeur.ResourceDirecteur))]
        [Display(Name = "prenom", ResourceType = typeof(Resources.ModelsResources.Directeur.ResourceDirecteur))]
        public string Prenom { get; set; }

        [Required(ErrorMessageResourceName = "emailEr", ErrorMessageResourceType = typeof(Resources.ModelsResources.Directeur.ResourceDirecteur))]
        [EmailAddress(ErrorMessageResourceName = "emailErr", ErrorMessageResourceType = typeof(Resources.ModelsResources.Directeur.ResourceDirecteur))]
        [Display(Name = "email", ResourceType = typeof(Resources.ModelsResources.Directeur.ResourceDirecteur))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "pwdEr", ErrorMessageResourceType = typeof(Resources.ModelsResources.Directeur.ResourceDirecteur))]
        [DataType(DataType.Password)]
        [Display(Name = "pwd", ResourceType = typeof(Resources.ModelsResources.Directeur.ResourceDirecteur))]
        public string MotDePasse { get; set; }

        [Required(ErrorMessage = "Role obligatoire")]
        public string Role { get; set; }
        public ICollection<Admin> Admins { get; set; }
        public ICollection<Enseignant> Enseignants { get; set; }
    }
}