using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projet_asp.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Groupe { get; set; }
        public ICollection<Etudiant> Etudiants { get; set; }
        public ICollection<Enseignant> Enseignants { get; set; }
    }
}