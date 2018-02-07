namespace AnnuairePrisma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "idSociete", c => c.Int(nullable: false));
            CreateIndex("dbo.Contacts", "idSociete");
            AddForeignKey("dbo.Contacts", "idSociete", "dbo.Societes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "idSociete", "dbo.Societes");
            DropIndex("dbo.Contacts", new[] { "idSociete" });
            DropColumn("dbo.Contacts", "idSociete");
        }
    }
}
