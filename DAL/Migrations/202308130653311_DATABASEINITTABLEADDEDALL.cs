namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DATABASEINITTABLEADDEDALL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Creators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                        Occupation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Donators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Balance = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                        Occupation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventDonators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Donation = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        DId = c.Int(nullable: false),
                        EId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Donators", t => t.DId, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.EId, cascadeDelete: true)
                .Index(t => t.DId)
                .Index(t => t.EId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        StartAt = c.DateTime(nullable: false),
                        EndAt = c.DateTime(nullable: false),
                        Goal = c.Int(nullable: false),
                        Fund = c.Int(nullable: false),
                        AId = c.Int(),
                        CId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.AId)
                .ForeignKey("dbo.Creators", t => t.CId, cascadeDelete: true)
                .Index(t => t.AId)
                .Index(t => t.CId);
            
            CreateTable(
                "dbo.Memberships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        MaxGoal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventDonators", "EId", "dbo.Events");
            DropForeignKey("dbo.Events", "CId", "dbo.Creators");
            DropForeignKey("dbo.Events", "AId", "dbo.Admins");
            DropForeignKey("dbo.EventDonators", "DId", "dbo.Donators");
            DropIndex("dbo.Events", new[] { "CId" });
            DropIndex("dbo.Events", new[] { "AId" });
            DropIndex("dbo.EventDonators", new[] { "EId" });
            DropIndex("dbo.EventDonators", new[] { "DId" });
            DropTable("dbo.Memberships");
            DropTable("dbo.Events");
            DropTable("dbo.EventDonators");
            DropTable("dbo.Donators");
            DropTable("dbo.Creators");
            DropTable("dbo.Admins");
        }
    }
}
