namespace projet_asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Etudiants", "SectionId", "dbo.Sections");
            DropIndex("dbo.Etudiants", new[] { "SectionId" });
            RenameColumn(table: "dbo.Etudiants", name: "SectionId", newName: "Section_Id");
            AlterColumn("dbo.Etudiants", "Section_Id", c => c.Int());
            CreateIndex("dbo.Etudiants", "Section_Id");
            AddForeignKey("dbo.Etudiants", "Section_Id", "dbo.Sections", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Etudiants", "Section_Id", "dbo.Sections");
            DropIndex("dbo.Etudiants", new[] { "Section_Id" });
            AlterColumn("dbo.Etudiants", "Section_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Etudiants", name: "Section_Id", newName: "SectionId");
            CreateIndex("dbo.Etudiants", "SectionId");
            AddForeignKey("dbo.Etudiants", "SectionId", "dbo.Sections", "Id", cascadeDelete: true);
        }
    }
}
