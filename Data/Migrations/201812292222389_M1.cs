namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProgramActivities", "ActivityId", "dbo.Activities");
            DropForeignKey("dbo.Likes", "PublicationId", "dbo.Publications");
            DropForeignKey("dbo.Likes", "UserId", "dbo.Users");
            DropForeignKey("dbo.Publications", "Program_ID", "dbo.Programs");
            DropForeignKey("dbo.Publications", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Comments", "PublicationId", "dbo.Publications");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Follows", "Follower_ID", "dbo.Users");
            DropForeignKey("dbo.Follows", "Following_ID", "dbo.Users");
            DropForeignKey("dbo.Notifications", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Progresses", "UserId", "dbo.Users");
            DropForeignKey("dbo.Messages", "Reciever_ID", "dbo.Users");
            DropForeignKey("dbo.SelectedPrograms", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.SelectedPrograms", "UserId", "dbo.Users");
            DropForeignKey("dbo.Messages", "Sender_ID", "dbo.Users");
            DropForeignKey("dbo.Nutritions", "Id", "dbo.Users");
            DropForeignKey("dbo.ProgramNutritions", "NutritionId", "dbo.Nutritions");
            DropForeignKey("dbo.ProgramNutritions", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.Programs", "UserId", "dbo.Users");
            DropForeignKey("dbo.ProgramActivities", "ProgramId", "dbo.Programs");
            DropIndex("dbo.ProgramActivities", new[] { "ProgramId" });
            DropIndex("dbo.ProgramActivities", new[] { "ActivityId" });
            DropIndex("dbo.Programs", new[] { "UserId" });
            DropIndex("dbo.ProgramNutritions", new[] { "ProgramId" });
            DropIndex("dbo.ProgramNutritions", new[] { "NutritionId" });
            DropIndex("dbo.Nutritions", new[] { "Id" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "PublicationId" });
            DropIndex("dbo.Publications", new[] { "User_ID" });
            DropIndex("dbo.Publications", new[] { "Program_ID" });
            DropIndex("dbo.Likes", new[] { "UserId" });
            DropIndex("dbo.Likes", new[] { "PublicationId" });
            DropIndex("dbo.Follows", new[] { "Follower_ID" });
            DropIndex("dbo.Follows", new[] { "Following_ID" });
            DropIndex("dbo.Notifications", new[] { "User_ID" });
            DropIndex("dbo.Progresses", new[] { "UserId" });
            DropIndex("dbo.Messages", new[] { "Sender_ID" });
            DropIndex("dbo.Messages", new[] { "Reciever_ID" });
            DropIndex("dbo.SelectedPrograms", new[] { "UserId" });
            DropIndex("dbo.SelectedPrograms", new[] { "ProgramId" });
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        IdUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.IdUser, cascadeDelete: true)
                .Index(t => t.IdUser);
            
            DropColumn("dbo.Users", "Mail");
            DropColumn("dbo.Users", "Pseudo");
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "ProfilePictureGeneratedName");
            DropTable("dbo.Activities");
            DropTable("dbo.ProgramActivities");
            DropTable("dbo.Programs");
            DropTable("dbo.ProgramNutritions");
            DropTable("dbo.Nutritions");
            DropTable("dbo.Comments");
            DropTable("dbo.Publications");
            DropTable("dbo.Likes");
            DropTable("dbo.Follows");
            DropTable("dbo.Notifications");
            DropTable("dbo.Progresses");
            DropTable("dbo.Messages");
            DropTable("dbo.SelectedPrograms");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SelectedPrograms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProgramId = c.Int(nullable: false),
                        DateOfSelect = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false),
                        Sender_ID = c.Int(nullable: false),
                        Reciever_ID = c.Int(nullable: false),
                        Content = c.String(),
                        MessageDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => new { t.MessageId, t.Sender_ID, t.Reciever_ID });
            
            CreateTable(
                "dbo.Progresses",
                c => new
                    {
                        ProgressId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Weight = c.Single(nullable: false),
                        ProgressDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ProgressId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        DateOfNotification = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Seen = c.Boolean(nullable: false),
                        NotificationType = c.Int(nullable: false),
                        User_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NotificationId);
            
            CreateTable(
                "dbo.Follows",
                c => new
                    {
                        FollowId = c.Int(nullable: false),
                        Follower_ID = c.Int(nullable: false),
                        Following_ID = c.Int(nullable: false),
                        FollowingDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => new { t.FollowId, t.Follower_ID, t.Following_ID });
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        LikeId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PublicationId = c.Int(nullable: false),
                        DateOfLike = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => new { t.LikeId, t.UserId, t.PublicationId });
            
            CreateTable(
                "dbo.Publications",
                c => new
                    {
                        PublicationId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        DateOfPublication = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PublicationPictureGeneratedName = c.String(),
                        User_ID = c.Int(nullable: false),
                        Program_ID = c.Int(),
                    })
                .PrimaryKey(t => t.PublicationId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PublicationId = c.Int(nullable: false),
                        DateOfComment = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Content = c.String(),
                    })
                .PrimaryKey(t => new { t.CommentId, t.UserId, t.PublicationId });
            
            CreateTable(
                "dbo.Nutritions",
                c => new
                    {
                        NutritionId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Calories = c.Single(nullable: false),
                        Protein = c.Single(nullable: false),
                        Fat = c.Single(nullable: false),
                        Carbs = c.Single(nullable: false),
                        Id = c.Int(),
                        NutritionPictureGeneratedName = c.String(),
                    })
                .PrimaryKey(t => t.NutritionId);
            
            CreateTable(
                "dbo.ProgramNutritions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProgramId = c.Int(nullable: false),
                        NutritionId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        TimeOfEating = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => new { t.Id, t.ProgramId, t.NutritionId });
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        ProgramId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Title = c.String(),
                        ProgramCreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProgramId);
            
            CreateTable(
                "dbo.ProgramActivities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProgramId = c.Int(nullable: false),
                        ActivityId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        TimeOfActivity = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => new { t.Id, t.ProgramId, t.ActivityId });
            
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CaloriesBurning = c.Single(nullable: false),
                        MuscleBuilding = c.Int(nullable: false),
                        FatBurning = c.Int(nullable: false),
                        Endurance = c.Int(nullable: false),
                        ActivityPictureGeneratedName = c.String(),
                    })
                .PrimaryKey(t => t.ActivityId);
            
            AddColumn("dbo.Users", "ProfilePictureGeneratedName", c => c.String());
            AddColumn("dbo.Users", "Password", c => c.String());
            AddColumn("dbo.Users", "Pseudo", c => c.String());
            AddColumn("dbo.Users", "Mail", c => c.String(nullable: false));
            DropForeignKey("dbo.Products", "IdUser", "dbo.Users");
            DropIndex("dbo.Products", new[] { "IdUser" });
            DropTable("dbo.Products");
            CreateIndex("dbo.SelectedPrograms", "ProgramId");
            CreateIndex("dbo.SelectedPrograms", "UserId");
            CreateIndex("dbo.Messages", "Reciever_ID");
            CreateIndex("dbo.Messages", "Sender_ID");
            CreateIndex("dbo.Progresses", "UserId");
            CreateIndex("dbo.Notifications", "User_ID");
            CreateIndex("dbo.Follows", "Following_ID");
            CreateIndex("dbo.Follows", "Follower_ID");
            CreateIndex("dbo.Likes", "PublicationId");
            CreateIndex("dbo.Likes", "UserId");
            CreateIndex("dbo.Publications", "Program_ID");
            CreateIndex("dbo.Publications", "User_ID");
            CreateIndex("dbo.Comments", "PublicationId");
            CreateIndex("dbo.Comments", "UserId");
            CreateIndex("dbo.Nutritions", "Id");
            CreateIndex("dbo.ProgramNutritions", "NutritionId");
            CreateIndex("dbo.ProgramNutritions", "ProgramId");
            CreateIndex("dbo.Programs", "UserId");
            CreateIndex("dbo.ProgramActivities", "ActivityId");
            CreateIndex("dbo.ProgramActivities", "ProgramId");
            AddForeignKey("dbo.ProgramActivities", "ProgramId", "dbo.Programs", "ProgramId");
            AddForeignKey("dbo.Programs", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.ProgramNutritions", "ProgramId", "dbo.Programs", "ProgramId");
            AddForeignKey("dbo.ProgramNutritions", "NutritionId", "dbo.Nutritions", "NutritionId");
            AddForeignKey("dbo.Nutritions", "Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Messages", "Sender_ID", "dbo.Users", "Id");
            AddForeignKey("dbo.SelectedPrograms", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.SelectedPrograms", "ProgramId", "dbo.Programs", "ProgramId");
            AddForeignKey("dbo.Messages", "Reciever_ID", "dbo.Users", "Id");
            AddForeignKey("dbo.Progresses", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.Notifications", "User_ID", "dbo.Users", "Id");
            AddForeignKey("dbo.Follows", "Following_ID", "dbo.Users", "Id");
            AddForeignKey("dbo.Follows", "Follower_ID", "dbo.Users", "Id");
            AddForeignKey("dbo.Comments", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.Comments", "PublicationId", "dbo.Publications", "PublicationId");
            AddForeignKey("dbo.Publications", "User_ID", "dbo.Users", "Id");
            AddForeignKey("dbo.Publications", "Program_ID", "dbo.Programs", "ProgramId");
            AddForeignKey("dbo.Likes", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.Likes", "PublicationId", "dbo.Publications", "PublicationId");
            AddForeignKey("dbo.ProgramActivities", "ActivityId", "dbo.Activities", "ActivityId");
        }
    }
}
