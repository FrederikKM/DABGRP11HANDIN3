namespace DABHandIn3_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlternativeAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetName = c.String(),
                        City = c.String(),
                        HouseNumber = c.String(),
                        ZipCode = c.String(),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Relation = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhoneNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Usage = c.String(),
                        PhoneCompany = c.String(),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.PrimaryAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetName = c.String(),
                        City = c.String(),
                        HouseNumber = c.String(),
                        ZipCode = c.String(),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrimaryAddresses", "PersonId", "dbo.People");
            DropForeignKey("dbo.PhoneNumbers", "PersonId", "dbo.People");
            DropForeignKey("dbo.AlternativeAddresses", "PersonId", "dbo.People");
            DropIndex("dbo.PrimaryAddresses", new[] { "PersonId" });
            DropIndex("dbo.PhoneNumbers", new[] { "PersonId" });
            DropIndex("dbo.AlternativeAddresses", new[] { "PersonId" });
            DropTable("dbo.PrimaryAddresses");
            DropTable("dbo.PhoneNumbers");
            DropTable("dbo.People");
            DropTable("dbo.AlternativeAddresses");
        }
    }
}
