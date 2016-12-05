namespace Scheduling_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TimeSlots", "available_from", c => c.Time(precision: 7));
            AlterColumn("dbo.TimeSlots", "available_to", c => c.Time(precision: 7));
           // DropTable("dbo.TimeSlotsVMs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TimeSlotsVMs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        available_from = c.DateTime(),
                        available_to = c.DateTime(),
                        is_holiday = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.TimeSlots", "available_to", c => c.DateTime());
            AlterColumn("dbo.TimeSlots", "available_from", c => c.DateTime());
        }
    }
}
