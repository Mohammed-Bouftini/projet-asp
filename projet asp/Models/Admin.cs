using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace projet_asp.Models
{
    public class Admin
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceName ="nomErr",ErrorMessageResourceType =typeof(Resources.ModelsResources.Admin.ResourceAdmin))]
        [Display(Name = "nom",ResourceType =typeof(Resources.ModelsResources.Admin.ResourceAdmin))]

        public string Nom { get; set; }
        [Required(ErrorMessageResourceName = "prenomErr", ErrorMessageResourceType = typeof(Resources.ModelsResources.Admin.ResourceAdmin))]
        [Display(Name = "prenom", ResourceType = typeof(Resources.ModelsResources.Admin.ResourceAdmin))]
        public string Prenom { get; set; }

        [Required(ErrorMessageResourceName = "emailEr", ErrorMessageResourceType = typeof(Resources.ModelsResources.Admin.ResourceAdmin))]
        [EmailAddress(ErrorMessageResourceName = "emailErr", ErrorMessageResourceType = typeof(Resources.ModelsResources.Admin.ResourceAdmin))]
        [Display(Name = "email", ResourceType = typeof(Resources.ModelsResources.Admin.ResourceAdmin))]
        public string Email { get; set; }
        [Required(ErrorMessageResourceName = "pwdEr", ErrorMessageResourceType = typeof(Resources.ModelsResources.Admin.ResourceAdmin))]
        [DataType(DataType.Password)]
        [Display(Name = "pwd", ResourceType = typeof(Resources.ModelsResources.Admin.ResourceAdmin))]
        public string MotDePasse { get; set; }
        public string Role { get; set; }
    }
}