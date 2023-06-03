using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Xml.Linq;

namespace projet_asp.Models
{
    public class Section
    {
        public int Id { get; set; }
        [Display(Name = "groupe", ResourceType = typeof(Resources.ModelsResources.Section.ResourceSection))]
        public string Groupe { get; set; }
        public ICollection<Etudiant> Etudiants { get; set; }
        public ICollection<Enseignant> Enseignants { get; set; }
    }
}