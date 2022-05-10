namespace Obligatorisk_opg_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Laaner_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Laaners", t => t.Laaner_ID)
                .Index(t => t.Laaner_ID);
            
            CreateTable(
                "dbo.Laaners",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Adresse = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bogs", "Laaner_ID", "dbo.Laaners");
            DropIndex("dbo.Bogs", new[] { "Laaner_ID" });
            DropTable("dbo.Laaners");
            DropTable("dbo.Bogs");
        }
    }
}
