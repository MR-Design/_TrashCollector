namespace _TrashCollector_DCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIDCustInfo : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CustomerInfoes");
            AddColumn("dbo.CustomerInfoes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CustomerInfoes", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CustomerInfoes");
            DropColumn("dbo.CustomerInfoes", "Id");
            AddPrimaryKey("dbo.CustomerInfoes", "Money");
        }
    }
}
