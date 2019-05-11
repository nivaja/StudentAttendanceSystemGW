namespace StudentAttendanceSystemGW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgragain54 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classes", "ClassType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Classes", "ClassType");
        }
    }
}
