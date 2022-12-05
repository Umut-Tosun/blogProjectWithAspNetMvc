namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newColumnContactTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "dateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "dateTime");
        }
    }
}
