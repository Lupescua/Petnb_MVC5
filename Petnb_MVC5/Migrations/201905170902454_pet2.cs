namespace Petnb_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pet2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OwnerUsers",
                c => new
                    {
                        OwnerUserId = c.Int(nullable: false, identity: true),
                        Review_ReviewId = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OwnerUserId)
                .ForeignKey("dbo.Reviews", t => t.Review_ReviewId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.Review_ReviewId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Rating = c.Double(),
                        Address = c.String(),
                        Age = c.Int(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        SitterUserId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Review_ReviewId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Reviews", t => t.Review_ReviewId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Review_ReviewId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        SitterUserId = c.String(),
                        OwnerUserId = c.String(),
                        Heading = c.String(),
                        Content = c.String(),
                        Rating = c.Double(nullable: false),
                        DateGiven = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.PetSitterOffers",
                c => new
                    {
                        PetSitterOfferId = c.Int(nullable: false, identity: true),
                        Heading = c.String(),
                        Content = c.String(),
                        Location = c.String(),
                        StartOfSit = c.DateTime(nullable: false),
                        EndOfSit = c.DateTime(nullable: false),
                        ExpectedSalary = c.Int(nullable: false),
                        OwnerUserId = c.String(),
                        OwnerUser_OwnerUserId = c.Int(),
                        SitterUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PetSitterOfferId)
                .ForeignKey("dbo.OwnerUsers", t => t.OwnerUser_OwnerUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.SitterUser_Id)
                .Index(t => t.OwnerUser_OwnerUserId)
                .Index(t => t.SitterUser_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        PetId = c.Int(nullable: false, identity: true),
                        PetName = c.String(),
                        PetType = c.Int(nullable: false),
                        PetAge = c.Int(nullable: false),
                        PetDifficulty = c.Double(nullable: false),
                        PetWeight = c.Double(nullable: false),
                        PetBreed = c.String(),
                        OwnerUserId = c.String(),
                        OwnerUser_OwnerUserId = c.Int(),
                    })
                .PrimaryKey(t => t.PetId)
                .ForeignKey("dbo.OwnerUsers", t => t.OwnerUser_OwnerUserId)
                .Index(t => t.OwnerUser_OwnerUserId);
            
            CreateTable(
                "dbo.PetOffers",
                c => new
                    {
                        PetOfferId = c.Int(nullable: false, identity: true),
                        Heading = c.String(),
                        Content = c.String(),
                        Reward = c.Decimal(precision: 18, scale: 2),
                        PetLocation = c.String(),
                        PetNeeds = c.String(),
                        StartOfSit = c.DateTime(nullable: false),
                        EndOfSit = c.DateTime(nullable: false),
                        PetId = c.String(),
                        SitterUserId = c.String(maxLength: 128),
                        Pet_PetId = c.Int(),
                    })
                .PrimaryKey(t => t.PetOfferId)
                .ForeignKey("dbo.Pets", t => t.Pet_PetId)
                .ForeignKey("dbo.AspNetUsers", t => t.SitterUserId)
                .Index(t => t.SitterUserId)
                .Index(t => t.Pet_PetId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PetOffers", "SitterUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PetOffers", "Pet_PetId", "dbo.Pets");
            DropForeignKey("dbo.Pets", "OwnerUser_OwnerUserId", "dbo.OwnerUsers");
            DropForeignKey("dbo.OwnerUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reviews", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Review_ReviewId", "dbo.Reviews");
            DropForeignKey("dbo.PetSitterOffers", "SitterUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PetSitterOffers", "OwnerUser_OwnerUserId", "dbo.OwnerUsers");
            DropForeignKey("dbo.AspNetUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.OwnerUsers", "Review_ReviewId", "dbo.Reviews");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PetOffers", new[] { "Pet_PetId" });
            DropIndex("dbo.PetOffers", new[] { "SitterUserId" });
            DropIndex("dbo.Pets", new[] { "OwnerUser_OwnerUserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.PetSitterOffers", new[] { "SitterUser_Id" });
            DropIndex("dbo.PetSitterOffers", new[] { "OwnerUser_OwnerUserId" });
            DropIndex("dbo.Reviews", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Review_ReviewId" });
            DropIndex("dbo.AspNetUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.OwnerUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.OwnerUsers", new[] { "Review_ReviewId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PetOffers");
            DropTable("dbo.Pets");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.PetSitterOffers");
            DropTable("dbo.Reviews");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.OwnerUsers");
        }
    }
}
