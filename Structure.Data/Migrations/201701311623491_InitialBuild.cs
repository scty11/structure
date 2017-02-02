namespace Structure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialBuild : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        DateCreated = c.DateTime(),
                        DateUpdated = c.DateTime(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Gadgets",
                c => new
                    {
                        GadgetID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 8, scale: 2),
                        Image = c.String(),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GadgetID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.GadgetOrders",
                c => new
                    {
                        GadgetOrderID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        GadgetID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GadgetOrderID)
                .ForeignKey("dbo.Gadgets", t => t.GadgetID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.GadgetID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        OwnerName = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        Zip = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GadgetOrders", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.GadgetOrders", "GadgetID", "dbo.Gadgets");
            DropForeignKey("dbo.Gadgets", "CategoryID", "dbo.Categories");
            DropIndex("dbo.GadgetOrders", new[] { "GadgetID" });
            DropIndex("dbo.GadgetOrders", new[] { "OrderID" });
            DropIndex("dbo.Gadgets", new[] { "CategoryID" });
            DropTable("dbo.Orders");
            DropTable("dbo.GadgetOrders");
            DropTable("dbo.Gadgets");
            DropTable("dbo.Categories");
        }
    }
}
