using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace projet_asp.Models
{
    public class Note
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceName = "moyenneEr", ErrorMessageResourceType = typeof(Resources.ModelsResources.Note.ResourceNote))]
        [Range(0, 20,ErrorMessageResourceName = "moyenneErr", ErrorMessageResourceType = typeof(Resources.ModelsResources.Note.ResourceNote))]
        [Display(Name = "moyenne", ResourceType = typeof(Resources.ModelsResources.Note.ResourceNote))]
        public double moyenne { get; set; }

        [Required(ErrorMessageResourceName = "matiereEr", ErrorMessageResourceType = typeof(Resources.ModelsResources.Note.ResourceNote))]
        [Display(Name = "matiere", ResourceType = typeof(Resources.ModelsResources.Note.ResourceNote))]
        public int MatiereId { get; set; }

        [ForeignKey("MatiereId")]
        public virtual Matière Matiere { get; set; }


        [Required(ErrorMessageResourceName = "etudiantEr", ErrorMessageResourceType = typeof(Resources.ModelsResources.Note.ResourceNote))]
        [Display(Name = "etudiant", ResourceType = typeof(Resources.ModelsResources.Note.ResourceNote))]
        public int EtudiantId { get; set; }

        [ForeignKey("EtudiantId")]
        public virtual Etudiant Etudiant { get; set; }
    }
}