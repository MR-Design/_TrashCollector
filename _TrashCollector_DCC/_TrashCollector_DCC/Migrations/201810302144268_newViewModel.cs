namespace _TrashCollector_DCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newViewModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "RegistrationDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "RegistrationDate");
        }
    }
}
