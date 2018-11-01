namespace _TrashCollector_DCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsfsdf : DbMigration
    {
        public override void Up()
        {
      
            
       
            
            CreateTable(
                "dbo.CustomerInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Money = c.Double(nullable: false),
                        WeeklyPickup = c.String(),
                        SuspendPickupsStart = c.DateTime(),
                        SuspendPickupsEnd = c.DateTime(),
                        ExtraPickup = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
          
        
       
    
}
