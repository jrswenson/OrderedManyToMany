namespace OrderedManyToMany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderedRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        AssignedUserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AssignedUserId)
                .Index(t => t.AssignedUserId);
            
            CreateTable(
                "dbo.OrderedTasks",
                c => new
                    {
                        ParentId = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ParentId, t.TaskId })
                .ForeignKey("dbo.Tasks", t => t.ParentId, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.TaskId)
                .Index(t => t.ParentId)
                .Index(t => t.TaskId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderedTasks", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.OrderedTasks", "ParentId", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "AssignedUserId", "dbo.Users");
            DropForeignKey("dbo.OrderedRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.OrderedRoles", "RoleId", "dbo.Roles");
            DropIndex("dbo.OrderedTasks", new[] { "TaskId" });
            DropIndex("dbo.OrderedTasks", new[] { "ParentId" });
            DropIndex("dbo.Tasks", new[] { "AssignedUserId" });
            DropIndex("dbo.OrderedRoles", new[] { "RoleId" });
            DropIndex("dbo.OrderedRoles", new[] { "UserId" });
            DropTable("dbo.OrderedTasks");
            DropTable("dbo.Tasks");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.OrderedRoles");
        }
    }
}
