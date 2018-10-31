namespace _TrashCollector_DCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCityStateToEmployeeAndCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "City", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "State", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "Address", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "City", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "State", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "ZipCode", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "ZipCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "ZipCode", c => c.String(nullable: false));
            DropColumn("dbo.Employees", "ZipCode");
            DropColumn("dbo.Employees", "State");
            DropColumn("dbo.Employees", "City");
            DropColumn("dbo.Employees", "Address");
            DropColumn("dbo.Customers", "State");
            DropColumn("dbo.Customers", "City");
        }
    }
}
