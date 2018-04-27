namespace DABHandIn3_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class People : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhoneNumbers", "PersonId", "dbo.People");
            DropForeignKey("dbo.PrimaryAddresses", "PersonId", "dbo.People");
            DropIndex("dbo.PhoneNumbers", new[] { "PersonId" });
            DropIndex("dbo.PrimaryAddresses", new[] { "PersonId" });
            RenameColumn(table: "dbo.PhoneNumbers", name: "PersonId", newName: "Person_Id");
            RenameColumn(table: "dbo.PrimaryAddresses", name: "PersonId", newName: "Person_Id");
            AddColumn("dbo.PhoneNumbers", "PeopleId", c => c.Int(nullable: false));
            AddColumn("dbo.PrimaryAddresses", "PeopleId", c => c.Int(nullable: false));
            AlterColumn("dbo.PhoneNumbers", "Person_Id", c => c.Int());
            AlterColumn("dbo.PrimaryAddresses", "Person_Id", c => c.Int());
            CreateIndex("dbo.PhoneNumbers", "Person_Id");
            CreateIndex("dbo.PrimaryAddresses", "Person_Id");
            AddForeignKey("dbo.PhoneNumbers", "Person_Id", "dbo.People", "Id");
            AddForeignKey("dbo.PrimaryAddresses", "Person_Id", "dbo.People", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrimaryAddresses", "Person_Id", "dbo.People");
            DropForeignKey("dbo.PhoneNumbers", "Person_Id", "dbo.People");
            DropIndex("dbo.PrimaryAddresses", new[] { "Person_Id" });
            DropIndex("dbo.PhoneNumbers", new[] { "Person_Id" });
            AlterColumn("dbo.PrimaryAddresses", "Person_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.PhoneNumbers", "Person_Id", c => c.Int(nullable: false));
            DropColumn("dbo.PrimaryAddresses", "PeopleId");
            DropColumn("dbo.PhoneNumbers", "PeopleId");
            RenameColumn(table: "dbo.PrimaryAddresses", name: "Person_Id", newName: "PersonId");
            RenameColumn(table: "dbo.PhoneNumbers", name: "Person_Id", newName: "PersonId");
            CreateIndex("dbo.PrimaryAddresses", "PersonId");
            CreateIndex("dbo.PhoneNumbers", "PersonId");
            AddForeignKey("dbo.PrimaryAddresses", "PersonId", "dbo.People", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PhoneNumbers", "PersonId", "dbo.People", "Id", cascadeDelete: true);
        }
    }
}
