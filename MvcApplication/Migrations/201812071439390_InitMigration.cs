namespace MvcApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        IsPresent = c.Boolean(nullable: false),
                        IdStudent = c.Int(nullable: false),
                        IdClassRoom = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassRooms", t => t.IdClassRoom, cascadeDelete: false)
                .ForeignKey("dbo.Students", t => t.IdStudent, cascadeDelete: false)
                .Index(t => t.IdStudent)
                .Index(t => t.IdClassRoom);
            
            CreateTable(
                "dbo.ClassRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentClassRooms",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        ClassRoom_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.ClassRoom_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: false)
                .ForeignKey("dbo.ClassRooms", t => t.ClassRoom_Id, cascadeDelete: false)
                .Index(t => t.Student_Id)
                .Index(t => t.ClassRoom_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "IdStudent", "dbo.Students");
            DropForeignKey("dbo.Attendances", "IdClassRoom", "dbo.ClassRooms");
            DropForeignKey("dbo.StudentClassRooms", "ClassRoom_Id", "dbo.ClassRooms");
            DropForeignKey("dbo.StudentClassRooms", "Student_Id", "dbo.Students");
            DropIndex("dbo.StudentClassRooms", new[] { "ClassRoom_Id" });
            DropIndex("dbo.StudentClassRooms", new[] { "Student_Id" });
            DropIndex("dbo.Attendances", new[] { "IdClassRoom" });
            DropIndex("dbo.Attendances", new[] { "IdStudent" });
            DropTable("dbo.StudentClassRooms");
            DropTable("dbo.Students");
            DropTable("dbo.ClassRooms");
            DropTable("dbo.Attendances");
        }
    }
}
