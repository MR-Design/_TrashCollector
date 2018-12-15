namespace _TrashCollector_DCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditedStartandEndingDateforExtraPickUp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExtraPickups", "ExtraPickUp_start", c => c.DateTime());
            AddColumn("dbo.ExtraPickups", "ExtraPickUp_end", c => c.DateTime());
            DropColumn("dbo.ExtraPickups", "ExtraPickUp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExtraPickups", "ExtraPickUp", c => c.DateTime());
            DropColumn("dbo.ExtraPickups", "ExtraPickUp_end");
            DropColumn("dbo.ExtraPickups", "ExtraPickUp_start");
        }
    }
}
