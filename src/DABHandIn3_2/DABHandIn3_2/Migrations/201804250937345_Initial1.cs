namespace DABHandIn3_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AlternativeAddresses", "PersonId", "dbo.People");
            DropIndex("dbo.AlternativeAddresses", new[] { "PersonId" });
            RenameColumn(table: "dbo.AlternativeAddresses", name: "PersonId", newName: "Person_Id");
            AddColumn("dbo.AlternativeAddresses", "PeopleId", c => c.Int(nullable: false));
            AlterColumn("dbo.AlternativeAddresses", "Person_Id", c => c.Int());
            CreateIndex("dbo.AlternativeAddresses", "Person_Id");
            AddForeignKey("dbo.AlternativeAddresses", "Person_Id", "dbo.People", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlternativeAddresses", "Person_Id", "dbo.People");
            DropIndex("dbo.AlternativeAddresses", new[] { "Person_Id" });
            AlterColumn("dbo.AlternativeAddresses", "Person_Id", c => c.Int(nullable: false));
            DropColumn("dbo.AlternativeAddresses", "PeopleId");
            RenameColumn(table: "dbo.AlternativeAddresses", name: "Person_Id", newName: "PersonId");
            CreateIndex("dbo.AlternativeAddresses", "PersonId");
            AddForeignKey("dbo.AlternativeAddresses", "PersonId", "dbo.People", "Id", cascadeDelete: true);
        }
    }
}
