namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
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
                        Username = c.String(),
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
                        Username = c.String(),
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
                .ForeignKey("dbo.Donators", t => t.DId, cascadeDelete: false)
                .ForeignKey("dbo.Events", t => t.EId, cascadeDelete: false)
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
                .ForeignKey("dbo.Creators", t => t.CId, cascadeDelete: false)
                .Index(t => t.AId)
                .Index(t => t.CId);
            
            CreateTable(
                "dbo.MembershipCreators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Validity = c.DateTime(nullable: false),
                        CId = c.Int(nullable: false),
                        MId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Creators", t => t.CId, cascadeDelete: false)
                .ForeignKey("dbo.Memberships", t => t.MId, cascadeDelete: false)
                .Index(t => t.CId)
                .Index(t => t.MId);
            
            CreateTable(
                "dbo.Memberships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        MaxGoal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ExpiredAt = c.DateTime(),
                        Username = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Username)
                .Index(t => t.Username);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        RId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Username)
                .ForeignKey("dbo.Roles", t => t.RId, cascadeDelete: false)
                .Index(t => t.RId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "Username", "dbo.Users");
            DropForeignKey("dbo.Users", "RId", "dbo.Roles");
            DropForeignKey("dbo.MembershipCreators", "MId", "dbo.Memberships");
            DropForeignKey("dbo.MembershipCreators", "CId", "dbo.Creators");
            DropForeignKey("dbo.EventDonators", "EId", "dbo.Events");
            DropForeignKey("dbo.Events", "CId", "dbo.Creators");
            DropForeignKey("dbo.Events", "AId", "dbo.Admins");
            DropForeignKey("dbo.EventDonators", "DId", "dbo.Donators");
            DropIndex("dbo.Users", new[] { "RId" });
            DropIndex("dbo.Tokens", new[] { "Username" });
            DropIndex("dbo.MembershipCreators", new[] { "MId" });
            DropIndex("dbo.MembershipCreators", new[] { "CId" });
            DropIndex("dbo.Events", new[] { "CId" });
            DropIndex("dbo.Events", new[] { "AId" });
            DropIndex("dbo.EventDonators", new[] { "EId" });
            DropIndex("dbo.EventDonators", new[] { "DId" });
            DropTable("dbo.Users");
            DropTable("dbo.Tokens");
            DropTable("dbo.Roles");
            DropTable("dbo.Memberships");
            DropTable("dbo.MembershipCreators");
            DropTable("dbo.Events");
            DropTable("dbo.EventDonators");
            DropTable("dbo.Donators");
            DropTable("dbo.Creators");
            DropTable("dbo.Admins");
        }
    }
}
