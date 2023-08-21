namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullMembership : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MembershipCreators", "Validity", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembershipCreators", "Validity", c => c.DateTime(nullable: false));
        }
    }
}
