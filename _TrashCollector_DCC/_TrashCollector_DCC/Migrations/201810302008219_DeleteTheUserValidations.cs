namespace _TrashCollector_DCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTheUserValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Address", c => c.String());
            AlterColumn("dbo.Customers", "City", c => c.String());
            AlterColumn("dbo.Customers", "State", c => c.String());
            AlterColumn("dbo.Employees", "Address", c => c.String());
            AlterColumn("dbo.Employees", "City", c => c.String());
            AlterColumn("dbo.Employees", "State", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "State", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "State", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Address", c => c.String(nullable: false));
        }
    }
}
