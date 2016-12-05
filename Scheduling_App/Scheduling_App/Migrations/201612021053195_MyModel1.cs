namespace Scheduling_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SearchVMs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        firstname = c.String(),
                        lastname = c.String(),
                        service = c.String(),
                        servicedetials = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SearchVMs");
        }
    }
}
