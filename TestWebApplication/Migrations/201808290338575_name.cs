namespace TestWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FactTests", "UserIP", c => c.String());
            DropColumn("dbo.FactTests", "Session");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FactTests", "Session", c => c.Int(nullable: false));
            DropColumn("dbo.FactTests", "UserIP");
        }
    }
}
