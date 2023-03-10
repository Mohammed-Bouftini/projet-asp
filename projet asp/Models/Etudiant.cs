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
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le prénom est obligatoire")]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Please Enter Adresse")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Please Enter Mobile No")]
        [Display(Name = "Tel")]
        [StringLength(10, ErrorMessage = "The Mobile must contains 10 characters", MinimumLength = 10)]
        public string Tel { get; set; }

        [Required(ErrorMessage = "L'adresse e-mail est obligatoire")]
        [EmailAddress(ErrorMessage = "L'adresse e-mail n'est pas valide")]
        [Display(Name = "Adresse e-mail")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Le mot de passe est obligatoire")]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string MotDePasse { get; set; }
        public string Role { get; set; }

        public bool Validé { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}
