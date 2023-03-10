using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projet_asp.Models
{
    public class Matière
    {
        public int Id { get; set; }
        public string matiere { get; set; }
        public int EnseignantId { get; set; }

        [ForeignKey("EnseignantId")]
        public virtual Enseignant Enseignant { get; set; }
        public ICollection<Note> Notes { get; set; }

    }
}