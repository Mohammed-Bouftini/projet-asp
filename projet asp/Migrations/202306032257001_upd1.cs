namespace projet_asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upd1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Etudiants", "SectionId", "dbo.Sections");
            DropIndex("dbo.Etudiants", new[] { "SectionId" });
            AlterColumn("dbo.Admins", "Role", c => c.String());
            AlterColumn("dbo.Etudiants", "SectionId", c => c.Int());
            CreateIndex("dbo.Etudiants", "SectionId");
            AddForeignKey("dbo.Etudiants", "SectionId", "dbo.Sections", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Etudiants", "SectionId", "dbo.Sections");
            DropIndex("dbo.Etudiants", new[] { "SectionId" });
            AlterColumn("dbo.Etudiants", "SectionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Admins", "Role", c => c.String(nullable: false));
            CreateIndex("dbo.Etudiants", "SectionId");
            AddForeignKey("dbo.Etudiants", "SectionId", "dbo.Sections", "Id", cascadeDelete: true);
        }
    }
}
