namespace _TrashCollector_DCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsInitialSetUp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        WeeklyPickUpDay = c.String(),
                        WeeklyPickUpDayCompleted = c.Boolean(nullable: false),
                        Balance = c.Double(),
                        ExtraPickUp = c.DateTime(nullable: false),
                        ExtraPickUpComleted = c.Boolean(nullable: false),
                        Fee = c.Double(),
                        IsSuspended = c.Boolean(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Lat = c.String(),
                        Lng = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                        Lat = c.String(),
                        Lng = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
            DropTable("dbo.Customers");
        }
    }
}
