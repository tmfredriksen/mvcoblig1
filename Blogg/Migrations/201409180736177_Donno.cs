namespace Blogg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Donno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "BlogID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "BlogID");
        }
    }
}
