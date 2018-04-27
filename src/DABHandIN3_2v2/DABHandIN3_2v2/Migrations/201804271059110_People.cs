namespace DABHandIN3_2v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class People : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AlternativeAddresses", "PeopleId");
            DropColumn("dbo.PhoneNumbers", "PeopleId");
            DropColumn("dbo.PrimaryAddresses", "PeopleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PrimaryAddresses", "PeopleId", c => c.Int(nullable: false));
            AddColumn("dbo.PhoneNumbers", "PeopleId", c => c.Int(nullable: false));
            AddColumn("dbo.AlternativeAddresses", "PeopleId", c => c.Int(nullable: false));
        }
    }
}
