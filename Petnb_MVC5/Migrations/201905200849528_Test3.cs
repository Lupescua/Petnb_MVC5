namespace Petnb_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Reviews", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.Pets", "PetTypeEnum", c => c.Int(nullable: false));
            DropColumn("dbo.Reviews", "ApplicationUser_Id");
            DropColumn("dbo.Pets", "PetType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pets", "PetType", c => c.Int(nullable: false));
            AddColumn("dbo.Reviews", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Pets", "PetTypeEnum");
            CreateIndex("dbo.Reviews", "ApplicationUser_Id");
            AddForeignKey("dbo.Reviews", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
