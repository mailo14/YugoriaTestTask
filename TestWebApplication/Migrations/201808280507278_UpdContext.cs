namespace TestWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FactTestId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        TextAnswer = c.String(),
                        VariantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FactTests", t => t.FactTestId, cascadeDelete: true)
                //.ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                //.ForeignKey("dbo.Variants", t => t.VariantId, cascadeDelete: true)
                .Index(t => t.FactTestId)
                .Index(t => t.QuestionId)
                .Index(t => t.VariantId);
            
            CreateTable(
                "dbo.FactTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestId = c.Int(nullable: false),
                        Session = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.TestId, cascadeDelete: true)
                .Index(t => t.TestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "VariantId", "dbo.Variants");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Answers", "FactTestId", "dbo.FactTests");
            DropForeignKey("dbo.FactTests", "TestId", "dbo.Tests");
            DropIndex("dbo.FactTests", new[] { "TestId" });
            DropIndex("dbo.Answers", new[] { "VariantId" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropIndex("dbo.Answers", new[] { "FactTestId" });
            DropTable("dbo.FactTests");
            DropTable("dbo.Answers");
        }
    }
}
