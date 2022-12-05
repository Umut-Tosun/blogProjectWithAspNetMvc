namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newColumnsForAuthor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "Title", c => c.String(maxLength: 100));
            AddColumn("dbo.Authors", "Mail", c => c.String(maxLength: 100));
            AddColumn("dbo.Authors", "PhoneNumber", c => c.String(maxLength: 30));
            AddColumn("dbo.Authors", "Password", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "Password");
            DropColumn("dbo.Authors", "PhoneNumber");
            DropColumn("dbo.Authors", "Mail");
            DropColumn("dbo.Authors", "Title");
        }
    }
}
