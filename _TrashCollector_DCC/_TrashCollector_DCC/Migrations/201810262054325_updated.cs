namespace _TrashCollector_DCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Employees", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.Customers", new[] { "CustomerID" });
            DropIndex("dbo.Employees", new[] { "EmployeeID" });
            AddColumn("dbo.Customers", "ApplicationUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Employees", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "ApplicationUserId");
            CreateIndex("dbo.Employees", "ApplicationUserId");
            AddForeignKey("dbo.Customers", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Employees", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Customers", "CustomerID");
            DropColumn("dbo.Employees", "EmployeeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "EmployeeID", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "CustomerID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Employees", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "ApplicationUserId" });
            DropIndex("dbo.Customers", new[] { "ApplicationUserId" });
            DropColumn("dbo.Employees", "ApplicationUserId");
            DropColumn("dbo.Customers", "ApplicationUserId");
            CreateIndex("dbo.Employees", "EmployeeID");
            CreateIndex("dbo.Customers", "CustomerID");
            AddForeignKey("dbo.Employees", "EmployeeID", "dbo.Employees", "Id");
            AddForeignKey("dbo.Customers", "CustomerID", "dbo.Customers", "Id");
        }
    }
}
