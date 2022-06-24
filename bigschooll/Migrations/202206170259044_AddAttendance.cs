namespace bigschooll.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttendance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        AttendedId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CourseId, t.AttendedId })
                .ForeignKey("dbo.AspNetUsers", t => t.AttendedId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .Index(t => t.CourseId)
                .Index(t => t.AttendedId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Attendances", "AttendedId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "AttendedId" });
            DropIndex("dbo.Attendances", new[] { "CourseId" });
            DropTable("dbo.Attendances");
        }
    }
}
