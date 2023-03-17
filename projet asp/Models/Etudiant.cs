using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace projet_asp.Models
{
    public class Etudiant
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceName ="nomEr",ErrorMessageResourceType =typeof(Resources.ModelsResources.Etudiant.ResourceEtudiant))]
        [Display(Name = "nom",ResourceType =typeof(Resources.ModelsResources.Etudiant.ResourceEtudiant))]
        public string Nom { get; set; }

        [Required(ErrorMessageResourceName = "prenomEr", ErrorMessageResourceType = typeof(Resources.ModelsResources.Etudiant.ResourceEtudiant))]
        [Display(Name = "prenom", ResourceType = typeof(Resources.ModelsResources.Etudiant.ResourceEtudiant))]
        public string Prenom { get; set; }

        [Required(ErrorMessageResourceName = "adresseEr", ErrorMessageResourceType =typeof(Resources.ModelsResources.Etudiant.ResourceEtudiant))]
        [Display(Name = "adresse", ResourceType = typeof(Resources.ModelsResources.Etudiant.ResourceEtudiant))]
        public string Adress { get; set; }
        [Required(ErrorMessageResourceName = "teleEr", ErrorMessageResourceType =typeof(Resources.ModelsResources.Etudiant.ResourceEtudiant))]
        [Display(Name = "tele", ResourceType = typeof(Resources.ModelsResources.Etudiant.ResourceEtudiant))]
        [StringLength(10, ErrorMessageResourceName = "teleErr", ErrorMessageResourceType = typeof(Resources.ModelsResources.Etudiant.ResourceEtudiant), MinimumLength = 10)]
        public string Tel { get; set; }

        [Required(ErrorMessageResourceName = "emailEr", ErrorMessageResourceType =typeof(Resources.ModelsResources.Etudiant.ResourceEtudiant))]
        [EmailAddress(ErrorMessageResourceName = "emailErr", ErrorMessageResourceType = typeof(Resources.ModelsResources.Etudiant.ResourceEtudiant))]
        [Display(Name = "email", ResourceType = typeof(Resources.ModelsResources.Etudiant.ResourceEtudiant))]
        public string Email { get; set; }


        [Required(ErrorMessageResourceName = "pwdEr", ErrorMessageResourceType =typeof(Resources.ModelsResources.Etudiant.ResourceEtudiant))]
        [DataType(DataType.Password)]
        [Display(Name = "pwd", ResourceType = typeof(Resources.ModelsResources.Etudiant.ResourceEtudiant))]
        public string MotDePasse { get; set; }
        public string Role { get; set; }
        [Display(Name = "vld", ResourceType = typeof(Resources.ModelsResources.Etudiant.ResourceEtudiant))]
        public bool Validé { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}
