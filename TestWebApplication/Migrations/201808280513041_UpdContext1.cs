namespace TestWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdContext1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Variants", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Variants", new[] { "QuestionId" });
            AlterColumn("dbo.Variants", "QuestionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Variants", "QuestionId");
            AddForeignKey("dbo.Variants", "QuestionId", "dbo.Questions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Variants", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Variants", new[] { "QuestionId" });
            AlterColumn("dbo.Variants", "QuestionId", c => c.Int());
            CreateIndex("dbo.Variants", "QuestionId");
            AddForeignKey("dbo.Variants", "QuestionId", "dbo.Questions", "Id");
        }
    }
}
