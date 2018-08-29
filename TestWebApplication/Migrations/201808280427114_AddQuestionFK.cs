namespace TestWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuestionFK : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "TestId", c => c.Int());
            CreateIndex("dbo.Questions", "TestId");
            AddForeignKey("dbo.Questions", "TestId", "dbo.Tests", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "TestId", "dbo.Tests");
            DropIndex("dbo.Questions", new[] { "TestId" });
            AlterColumn("dbo.Questions", "TestId", c => c.Int(nullable: false));
        }
    }
}
