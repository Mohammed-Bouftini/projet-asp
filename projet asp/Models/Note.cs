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
        [Required(ErrorMessage = "La note est obligatoire")]
        [Range(0, 20, ErrorMessage = "La note doit être comprise entre 0 et 20")]
        [Display(Name = "Note")]
        public double moyenne { get; set; }

        [Required(ErrorMessage = "La matière est obligatoire")]
        [Display(Name = "Matière")]
        public int MatiereId { get; set; }

        [ForeignKey("MatiereId")]
        public virtual Matière Matiere { get; set; }


        [Required(ErrorMessage = "Étudiant est obligatoire")]
        [Display(Name = "ÉtudiantId")]
        public int EtudiantId { get; set; }

        [ForeignKey("EtudiantId")]
        public virtual Etudiant Etudiant { get; set; }
    }
}