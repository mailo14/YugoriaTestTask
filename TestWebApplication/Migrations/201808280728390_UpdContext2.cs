namespace TestWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdContext2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Answers", newName: "CheckAnswers");
            CreateTable(
                "dbo.TextAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FactTestId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FactTests", t => t.FactTestId, cascadeDelete: true)
                //.ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.FactTestId)
                .Index(t => t.QuestionId);
            
            DropColumn("dbo.CheckAnswers", "TextAnswer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CheckAnswers", "TextAnswer", c => c.String());
            DropForeignKey("dbo.TextAnswers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.TextAnswers", "FactTestId", "dbo.FactTests");
            DropIndex("dbo.TextAnswers", new[] { "QuestionId" });
            DropIndex("dbo.TextAnswers", new[] { "FactTestId" });
            DropTable("dbo.TextAnswers");
            RenameTable(name: "dbo.CheckAnswers", newName: "Answers");
        }
    }
}
