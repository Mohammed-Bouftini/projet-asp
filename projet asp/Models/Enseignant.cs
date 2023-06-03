using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace projet_asp.Models
{
    public class Enseignant
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceName = "nomEr", ErrorMessageResourceType = typeof(Resources.ModelsResources.Enseignant.ResourceEnseigant))]
        [Display(Name = "nom", ResourceType = typeof(Resources.ModelsResources.Enseignant.ResourceEnseigant))]
        public string Nom { get; set; }

        [Required(ErrorMessageResourceName = "prenomEr", ErrorMessageResourceType = typeof(Resources.ModelsResources.Enseignant.ResourceEnseigant))]
        [Display(Name = "prenom", ResourceType = typeof(Resources.ModelsResources.Enseignant.ResourceEnseigant))]
        public string Prenom { get; set; }

        [Required(ErrorMessageResourceName = "emailEr", ErrorMessageResourceType = typeof(Resources.ModelsResources.Enseignant.ResourceEnseigant))]
        [EmailAddress(ErrorMessageResourceName = "emailErr", ErrorMessageResourceType = typeof(Resources.ModelsResources.Enseignant.ResourceEnseigant))]
        [Display(Name = "email", ResourceType = typeof(Resources.ModelsResources.Enseignant.ResourceEnseigant))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "pwdEr", ErrorMessageResourceType = typeof(Resources.ModelsResources.Enseignant.ResourceEnseigant))]
        [DataType(DataType.Password)]
        [Display(Name = "pwd", ResourceType = typeof(Resources.ModelsResources.Enseignant.ResourceEnseigant))]
        public string MotDePasse { get; set; }
        public string Role { get; set; }
    }
}