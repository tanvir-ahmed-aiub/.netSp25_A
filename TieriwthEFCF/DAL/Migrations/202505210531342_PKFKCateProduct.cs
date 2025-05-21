namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PKFKCateProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "CatId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "CatId");
            AddForeignKey("dbo.Products", "CatId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CatId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CatId" });
            DropColumn("dbo.Products", "CatId");
        }
    }
}
