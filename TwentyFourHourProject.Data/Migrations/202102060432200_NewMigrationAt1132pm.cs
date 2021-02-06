namespace TwentyFourHourProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigrationAt1132pm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 500),
                        Author = c.Guid(nullable: false),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Reply",
                c => new
                    {
                        ReplyId = c.Int(nullable: false, identity: true),
                        CommentId = c.Int(nullable: false),
                        Author = c.Guid(nullable: false),
                        Text = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ReplyId)
                .ForeignKey("dbo.Comment", t => t.CommentId, cascadeDelete: true)
                .Index(t => t.CommentId);
            
            AddColumn("dbo.Post", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Post", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.Post", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Post", "Text", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reply", "CommentId", "dbo.Comment");
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropIndex("dbo.Reply", new[] { "CommentId" });
            DropIndex("dbo.Comment", new[] { "PostId" });
            AlterColumn("dbo.Post", "Text", c => c.String(nullable: false));
            AlterColumn("dbo.Post", "Title", c => c.String(nullable: false));
            DropColumn("dbo.Post", "ModifiedUtc");
            DropColumn("dbo.Post", "CreatedUtc");
            DropTable("dbo.Reply");
            DropTable("dbo.Comment");
        }
    }
}
