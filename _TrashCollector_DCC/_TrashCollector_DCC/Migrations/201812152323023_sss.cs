namespace _TrashCollector_DCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sss : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExtraPickups", "CustomerId", "dbo.Customers");
            DropIndex("dbo.ExtraPickups", new[] { "CustomerId" });
            AlterColumn("dbo.ExtraPickups", "CustomerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ExtraPickups", "CustomerId");
            AddForeignKey("dbo.ExtraPickups", "CustomerId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExtraPickups", "CustomerId", "dbo.AspNetUsers");
            DropIndex("dbo.ExtraPickups", new[] { "CustomerId" });
            AlterColumn("dbo.ExtraPickups", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.ExtraPickups", "CustomerId");
            AddForeignKey("dbo.ExtraPickups", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
