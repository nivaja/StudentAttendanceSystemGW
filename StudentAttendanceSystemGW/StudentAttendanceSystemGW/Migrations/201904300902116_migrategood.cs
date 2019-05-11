namespace StudentAttendanceSystemGW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrategood : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TimeTables", "Day", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TimeTables", "Day", c => c.String());
        }
    }
}
