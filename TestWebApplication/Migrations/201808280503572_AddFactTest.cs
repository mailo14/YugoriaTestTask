namespace TestWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFactTest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "TestId", "dbo.Tests");
            DropIndex("dbo.Questions", new[] { "TestId" });
            AlterColumn("dbo.Questions", "TestId", c => c.Int(nullable: false));
            CreateIndex("dbo.Questions", "TestId");
            AddForeignKey("dbo.Questions", "TestId", "dbo.Tests", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "TestId", "dbo.Tests");
            DropIndex("dbo.Questions", new[] { "TestId" });
            AlterColumn("dbo.Questions", "TestId", c => c.Int());
            CreateIndex("dbo.Questions", "TestId");
            AddForeignKey("dbo.Questions", "TestId", "dbo.Tests", "Id");
        }
    }
}
