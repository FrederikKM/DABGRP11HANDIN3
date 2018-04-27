namespace DABHandIn3_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Address : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AlternativeAddresses", "Person_Id", "dbo.People");
            DropForeignKey("dbo.PhoneNumbers", "Person_Id", "dbo.People");
            DropForeignKey("dbo.PrimaryAddresses", "Person_Id", "dbo.People");
            DropIndex("dbo.PrimaryAddresses", new[] { "Person_Id" });
            DropColumn("dbo.People", "Id");
            RenameColumn(table: "dbo.People", name: "Person_Id", newName: "Id");
            DropPrimaryKey("dbo.People");
            AlterColumn("dbo.People", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.People", "Id");
            CreateIndex("dbo.People", "Id");
            AddForeignKey("dbo.AlternativeAddresses", "Person_Id", "dbo.People", "Id");
            AddForeignKey("dbo.PhoneNumbers", "Person_Id", "dbo.People", "Id");
            DropColumn("dbo.AlternativeAddresses", "PeopleId");
            DropColumn("dbo.PhoneNumbers", "PeopleId");
            DropColumn("dbo.PrimaryAddresses", "PeopleId");
            DropColumn("dbo.PrimaryAddresses", "Person_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PrimaryAddresses", "Person_Id", c => c.Int());
            AddColumn("dbo.PrimaryAddresses", "PeopleId", c => c.Int(nullable: false));
            AddColumn("dbo.PhoneNumbers", "PeopleId", c => c.Int(nullable: false));
            AddColumn("dbo.AlternativeAddresses", "PeopleId", c => c.Int(nullable: false));
            DropForeignKey("dbo.PhoneNumbers", "Person_Id", "dbo.People");
            DropForeignKey("dbo.AlternativeAddresses", "Person_Id", "dbo.People");
            DropIndex("dbo.People", new[] { "Id" });
            DropPrimaryKey("dbo.People");
            AlterColumn("dbo.People", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.People", "Id");
            RenameColumn(table: "dbo.People", name: "Id", newName: "Person_Id");
            AddColumn("dbo.People", "Id", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.PrimaryAddresses", "Person_Id");
            AddForeignKey("dbo.PrimaryAddresses", "Person_Id", "dbo.People", "Id");
            AddForeignKey("dbo.PhoneNumbers", "Person_Id", "dbo.People", "Id");
            AddForeignKey("dbo.AlternativeAddresses", "Person_Id", "dbo.People", "Id");
        }
    }
}
