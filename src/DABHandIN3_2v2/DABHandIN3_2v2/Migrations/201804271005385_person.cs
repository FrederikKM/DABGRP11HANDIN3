namespace DABHandIN3_2v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class person : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "Id", "dbo.PrimaryAddresses");
            DropForeignKey("dbo.AlternativeAddresses", "Person_Id", "dbo.People");
            DropForeignKey("dbo.PhoneNumbers", "Person_Id", "dbo.People");
            DropIndex("dbo.People", new[] { "Id" });
            DropPrimaryKey("dbo.People");
            AddColumn("dbo.PrimaryAddresses", "Person_Id", c => c.Int());
            AlterColumn("dbo.People", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.People", "Id");
            CreateIndex("dbo.PrimaryAddresses", "Person_Id");
            AddForeignKey("dbo.PrimaryAddresses", "Person_Id", "dbo.People", "Id");
            AddForeignKey("dbo.AlternativeAddresses", "Person_Id", "dbo.People", "Id");
            AddForeignKey("dbo.PhoneNumbers", "Person_Id", "dbo.People", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhoneNumbers", "Person_Id", "dbo.People");
            DropForeignKey("dbo.AlternativeAddresses", "Person_Id", "dbo.People");
            DropForeignKey("dbo.PrimaryAddresses", "Person_Id", "dbo.People");
            DropIndex("dbo.PrimaryAddresses", new[] { "Person_Id" });
            DropPrimaryKey("dbo.People");
            AlterColumn("dbo.People", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.PrimaryAddresses", "Person_Id");
            AddPrimaryKey("dbo.People", "Id");
            CreateIndex("dbo.People", "Id");
            AddForeignKey("dbo.PhoneNumbers", "Person_Id", "dbo.People", "Id");
            AddForeignKey("dbo.AlternativeAddresses", "Person_Id", "dbo.People", "Id");
            AddForeignKey("dbo.People", "Id", "dbo.PrimaryAddresses", "Id");
        }
    }
}
