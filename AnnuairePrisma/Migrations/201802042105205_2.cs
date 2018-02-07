namespace AnnuairePrisma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Societes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Client = c.String(),
                        raisonSociale = c.String(),
                        Adresse = c.String(),
                        adresse2 = c.String(),
                        codePostal = c.String(),
                        ville = c.String(),
                        Telephone = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Societes");
        }
    }
}
