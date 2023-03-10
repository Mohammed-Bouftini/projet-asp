using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace projet_asp.Data
{
    public class projet_aspContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public projet_aspContext() : base("name=projet_aspContext")
        {
        }
        public System.Data.Entity.DbSet<projet_asp.Models.Etudiant> Etudiants { get; set; }
        public System.Data.Entity.DbSet<projet_asp.Models.Directeur> Directeurs { get; set; }

        public System.Data.Entity.DbSet<projet_asp.Models.Enseignant> Enseignants { get; set; }

        public System.Data.Entity.DbSet<projet_asp.Models.Admin> Admins { get; set; }

        public System.Data.Entity.DbSet<projet_asp.Models.Matière> Matière { get; set; }

        public System.Data.Entity.DbSet<projet_asp.Models.Note> Notes { get; set; }

        public System.Data.Entity.DbSet<projet_asp.Models.Account> Accounts { get; set; }

        public System.Data.Entity.DbSet<projet_asp.Models.Section> Sections { get; set; }
    }
}
