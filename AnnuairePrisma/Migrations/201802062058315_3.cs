namespace AnnuairePrisma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        civilite = c.String(),
                        nom = c.String(),
                        prenom = c.String(),
                        fonction = c.String(),
                        telportable = c.String(),
                        tel = c.String(),
                        mail = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacts");
        }
    }
}
