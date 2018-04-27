namespace DABHandIN3_2v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PeopleID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlternativeAddresses", "PeopleId", c => c.Int(nullable: false));
            AddColumn("dbo.PhoneNumbers", "PeopleId", c => c.Int(nullable: false));
            AddColumn("dbo.PrimaryAddresses", "PeopleId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PrimaryAddresses", "PeopleId");
            DropColumn("dbo.PhoneNumbers", "PeopleId");
            DropColumn("dbo.AlternativeAddresses", "PeopleId");
        }
    }
}
