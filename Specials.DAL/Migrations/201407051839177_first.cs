namespace Specials.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        PlaceId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PlaceId);
            
            CreateTable(
                "dbo.Specials",
                c => new
                    {
                        SpecialId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PlaceId = c.Int(nullable: false),
                        IsValid = c.Boolean(nullable: false),
                        DayOfWeek = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SpecialId)
                .ForeignKey("dbo.Places", t => t.PlaceId, cascadeDelete: true)
                .Index(t => t.PlaceId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Rating = c.Int(nullable: false),
                        SpecialId = c.Int(nullable: false),
                        IsPublic = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Specials", t => t.SpecialId, cascadeDelete: true)
                .Index(t => t.SpecialId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.SpecialTags",
                c => new
                    {
                        SpecialId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SpecialId, t.TagId })
                .ForeignKey("dbo.Specials", t => t.SpecialId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.SpecialId)
                .Index(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecialTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.SpecialTags", "SpecialId", "dbo.Specials");
            DropForeignKey("dbo.Reviews", "SpecialId", "dbo.Specials");
            DropForeignKey("dbo.Specials", "PlaceId", "dbo.Places");
            DropIndex("dbo.SpecialTags", new[] { "TagId" });
            DropIndex("dbo.SpecialTags", new[] { "SpecialId" });
            DropIndex("dbo.Reviews", new[] { "SpecialId" });
            DropIndex("dbo.Specials", new[] { "PlaceId" });
            DropTable("dbo.SpecialTags");
            DropTable("dbo.Tags");
            DropTable("dbo.Reviews");
            DropTable("dbo.Specials");
            DropTable("dbo.Places");
        }
    }
}
