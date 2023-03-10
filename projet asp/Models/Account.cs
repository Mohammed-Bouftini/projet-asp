using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace projet_asp.Models
{
    public class Account
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "L'adresse e-mail est obligatoire")]
        [EmailAddress(ErrorMessage = "L'adresse e-mail n'est pas valide")]
        [Display(Name = "Adresse e-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Le mot de passe est obligatoire")]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}