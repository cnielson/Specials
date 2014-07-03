namespace Specials.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
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
                        IsValid = c.Boolean(nullable: false),
                        Place_PlaceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SpecialId)
                .ForeignKey("dbo.Places", t => t.Place_PlaceId, cascadeDelete: true)
                .Index(t => t.Place_PlaceId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Rating = c.Int(nullable: false),
                        IsPublic = c.Boolean(nullable: false),
                        Special_SpecialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Specials", t => t.Special_SpecialId, cascadeDelete: true)
                .Index(t => t.Special_SpecialId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.TagSpecials",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Special_SpecialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Special_SpecialId })
                .ForeignKey("dbo.Tags", t => t.Tag_TagId, cascadeDelete: true)
                .ForeignKey("dbo.Specials", t => t.Special_SpecialId, cascadeDelete: true)
                .Index(t => t.Tag_TagId)
                .Index(t => t.Special_SpecialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagSpecials", "Special_SpecialId", "dbo.Specials");
            DropForeignKey("dbo.TagSpecials", "Tag_TagId", "dbo.Tags");
            DropForeignKey("dbo.Reviews", "Special_SpecialId", "dbo.Specials");
            DropForeignKey("dbo.Specials", "Place_PlaceId", "dbo.Places");
            DropIndex("dbo.TagSpecials", new[] { "Special_SpecialId" });
            DropIndex("dbo.TagSpecials", new[] { "Tag_TagId" });
            DropIndex("dbo.Reviews", new[] { "Special_SpecialId" });
            DropIndex("dbo.Specials", new[] { "Place_PlaceId" });
            DropTable("dbo.TagSpecials");
            DropTable("dbo.Tags");
            DropTable("dbo.Reviews");
            DropTable("dbo.Specials");
            DropTable("dbo.Places");
        }
    }
}
