namespace StudentAttendanceSystemGW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nint1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "TeachingHours", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "TeachingHours", c => c.Double(nullable: false));
        }
    }
}
