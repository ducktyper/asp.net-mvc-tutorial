namespace MvcTutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProductReview : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductReviews", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductReviews", new[] { "ProductId" });
            DropTable("dbo.ProductReviews");
        }
    }
}
