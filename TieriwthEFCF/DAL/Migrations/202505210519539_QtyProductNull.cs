namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QtyProductNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Qty", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Qty", c => c.Int(nullable: false));
        }
    }
}
