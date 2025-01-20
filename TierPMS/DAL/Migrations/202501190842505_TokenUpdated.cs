namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TokenUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tokens", "ExpiredAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tokens", "ExpiredAt", c => c.DateTime(nullable: false));
        }
    }
}
