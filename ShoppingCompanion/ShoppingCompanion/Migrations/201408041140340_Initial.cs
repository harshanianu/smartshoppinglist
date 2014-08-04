namespace ShoppingCompanion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateTable(
                "dbo.ParentStore",
                c => new
                    {
                        ParentId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ParentId);
            
            CreateTable(
                "dbo.Promotion",
                c => new
                    {
                        PromotionId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        StartDate = c.DateTime(nullable: false, precision: 0),
                        EndDate = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.PromotionId);
            
            CreateTable(
                "dbo.Store",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Lattitude = c.Single(nullable: false),
                        Longitute = c.Single(nullable: false),
                        Address = c.String(unicode: false),
                        IsOpened = c.Boolean(nullable: false),
                        ParentStoreId = c.Int(nullable: false),
                        ParentStore_ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.StoreId)
                .ForeignKey("dbo.ParentStore", t => t.ParentStore_ParentId)
                .Index(t => t.ParentStore_ParentId);
            
            CreateTable(
                "dbo.ItemCategory",
                c => new
                    {
                        Item_ItemId = c.Int(nullable: false),
                        Category_CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Item_ItemId, t.Category_CategoryId })
                .ForeignKey("dbo.Item", t => t.Item_ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.Category_CategoryId, cascadeDelete: true)
                .Index(t => t.Item_ItemId)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.ParentStoreCategory",
                c => new
                    {
                        ParentStore_ParentId = c.Int(nullable: false),
                        Category_CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ParentStore_ParentId, t.Category_CategoryId })
                .ForeignKey("dbo.ParentStore", t => t.ParentStore_ParentId, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.Category_CategoryId, cascadeDelete: true)
                .Index(t => t.ParentStore_ParentId)
                .Index(t => t.Category_CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Store", "ParentStore_ParentId", "dbo.ParentStore");
            DropForeignKey("dbo.ParentStoreCategory", "Category_CategoryId", "dbo.Category");
            DropForeignKey("dbo.ParentStoreCategory", "ParentStore_ParentId", "dbo.ParentStore");
            DropForeignKey("dbo.ItemCategory", "Category_CategoryId", "dbo.Category");
            DropForeignKey("dbo.ItemCategory", "Item_ItemId", "dbo.Item");
            DropIndex("dbo.ParentStoreCategory", new[] { "Category_CategoryId" });
            DropIndex("dbo.ParentStoreCategory", new[] { "ParentStore_ParentId" });
            DropIndex("dbo.ItemCategory", new[] { "Category_CategoryId" });
            DropIndex("dbo.ItemCategory", new[] { "Item_ItemId" });
            DropIndex("dbo.Store", new[] { "ParentStore_ParentId" });
            DropTable("dbo.ParentStoreCategory");
            DropTable("dbo.ItemCategory");
            DropTable("dbo.Store");
            DropTable("dbo.Promotion");
            DropTable("dbo.ParentStore");
            DropTable("dbo.Item");
            DropTable("dbo.Category");
        }
    }
}
