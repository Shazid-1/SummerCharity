namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullEventEndAt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "EndAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "EndAt", c => c.DateTime(nullable: false));
        }
    }
}
