namespace projet_asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        Prenom = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        MotDePasse = c.String(nullable: false),
                        Role = c.String(nullable: false),
                        Directeur_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Directeurs", t => t.Directeur_Id)
                .Index(t => t.Directeur_Id);
            
            CreateTable(
                "dbo.Directeurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        Prenom = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        MotDePasse = c.String(nullable: false),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Enseignants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        Prenom = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        MotDePasse = c.String(nullable: false),
                        Role = c.String(),
                        Directeur_Id = c.Int(),
                        Section_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Directeurs", t => t.Directeur_Id)
                .ForeignKey("dbo.Sections", t => t.Section_Id)
                .Index(t => t.Directeur_Id)
                .Index(t => t.Section_Id);
            
            CreateTable(
                "dbo.Etudiants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        Prenom = c.String(nullable: false),
                        Adress = c.String(nullable: false),
                        Tel = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false),
                        MotDePasse = c.String(nullable: false),
                        SectionId = c.Int(nullable: false),
                        Role = c.String(),
                        Validé = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: true)
                .Index(t => t.SectionId);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        moyenne = c.Double(nullable: false),
                        MatiereId = c.Int(nullable: false),
                        EtudiantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Etudiants", t => t.EtudiantId, cascadeDelete: true)
                .ForeignKey("dbo.Matière", t => t.MatiereId, cascadeDelete: true)
                .Index(t => t.MatiereId)
                .Index(t => t.EtudiantId);
            
            CreateTable(
                "dbo.Matière",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        matiere = c.String(),
                        EnseignantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enseignants", t => t.EnseignantId, cascadeDelete: true)
                .Index(t => t.EnseignantId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Groupe = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Etudiants", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.Enseignants", "Section_Id", "dbo.Sections");
            DropForeignKey("dbo.Notes", "MatiereId", "dbo.Matière");
            DropForeignKey("dbo.Matière", "EnseignantId", "dbo.Enseignants");
            DropForeignKey("dbo.Notes", "EtudiantId", "dbo.Etudiants");
            DropForeignKey("dbo.Enseignants", "Directeur_Id", "dbo.Directeurs");
            DropForeignKey("dbo.Admins", "Directeur_Id", "dbo.Directeurs");
            DropIndex("dbo.Matière", new[] { "EnseignantId" });
            DropIndex("dbo.Notes", new[] { "EtudiantId" });
            DropIndex("dbo.Notes", new[] { "MatiereId" });
            DropIndex("dbo.Etudiants", new[] { "SectionId" });
            DropIndex("dbo.Enseignants", new[] { "Section_Id" });
            DropIndex("dbo.Enseignants", new[] { "Directeur_Id" });
            DropIndex("dbo.Admins", new[] { "Directeur_Id" });
            DropTable("dbo.Sections");
            DropTable("dbo.Matière");
            DropTable("dbo.Notes");
            DropTable("dbo.Etudiants");
            DropTable("dbo.Enseignants");
            DropTable("dbo.Directeurs");
            DropTable("dbo.Admins");
            DropTable("dbo.Accounts");
        }
    }
}
