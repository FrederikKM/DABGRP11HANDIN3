namespace DAB2_2RDBv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Phone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhoneNumbers", "PhoneCompany", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhoneNumbers", "PhoneCompany");
        }
    }
}
