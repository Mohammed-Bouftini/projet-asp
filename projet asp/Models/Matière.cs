using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Xml.Linq;

namespace projet_asp.Models
{
    public class Matière
    {
        public int Id { get; set; }
        [Display(Name = "matiere", ResourceType = typeof(Resources.ModelsResources.Matière.ResourceMatière))]
        public string matiere { get; set; }
       [Display(Name = "EnseignantId", ResourceType = typeof(Resources.ModelsResources.Matière.ResourceMatière))]
        public int EnseignantId { get; set; }

        [ForeignKey("EnseignantId")]
        public virtual Enseignant Enseignant { get; set; }
        public ICollection<Note> Notes { get; set; }

    }
}