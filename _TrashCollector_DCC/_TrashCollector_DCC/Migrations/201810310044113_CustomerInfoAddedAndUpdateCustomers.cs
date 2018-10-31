namespace _TrashCollector_DCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerInfoAddedAndUpdateCustomers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerInfoes",
                c => new
                    {
                        Money = c.Double(nullable: false),
                        WeeklyPickup = c.String(),
                        SuspendPickupsStart = c.DateTime(),
                        SuspendPickupsEnd = c.DateTime(),
                        ExtraPickup = c.DateTime(),
                    })
                .PrimaryKey(t => t.Money);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerInfoes");
        }
    }
}
