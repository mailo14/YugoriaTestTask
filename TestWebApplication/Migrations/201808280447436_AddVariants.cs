namespace TestWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVariants : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Variants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(),
                        Num = c.Int(nullable: false),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
            AddColumn("dbo.Questions", "Num", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Variants", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Variants", new[] { "QuestionId" });
            DropColumn("dbo.Questions", "Num");
            DropTable("dbo.Variants");
        }
    }
}
