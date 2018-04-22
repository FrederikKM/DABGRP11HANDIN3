namespace DAB2_2RDBv2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlternativeAddresses",
                c => new
                    {
                        AltAddressesId = c.Int(nullable: false, identity: true),
                        StreetName = c.String(),
                        City = c.String(),
                        HouseNumber = c.String(),
                        ZipCode = c.String(),
                        Person_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.AltAddressesId)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .Index(t => t.Person_PersonId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Relation = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.PrimaryAddresses", t => t.PersonId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.PhoneNumbers",
                c => new
                    {
                        PhoneNumberId = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Type = c.String(),
                        Person_PersonId = c.Int(),
                        Person_PersonId1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhoneNumberId)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .ForeignKey("dbo.People", t => t.Person_PersonId1, cascadeDelete: true)
                .Index(t => t.Person_PersonId)
                .Index(t => t.Person_PersonId1);
            
            CreateTable(
                "dbo.PrimaryAddresses",
                c => new
                    {
                        PrimaryAddressId = c.Int(nullable: false, identity: true),
                        StreetName = c.String(),
                        City = c.String(),
                        HouseNumber = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.PrimaryAddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "PersonId", "dbo.PrimaryAddresses");
            DropForeignKey("dbo.PhoneNumbers", "Person_PersonId1", "dbo.People");
            DropForeignKey("dbo.PhoneNumbers", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.AlternativeAddresses", "Person_PersonId", "dbo.People");
            DropIndex("dbo.PhoneNumbers", new[] { "Person_PersonId1" });
            DropIndex("dbo.PhoneNumbers", new[] { "Person_PersonId" });
            DropIndex("dbo.People", new[] { "PersonId" });
            DropIndex("dbo.AlternativeAddresses", new[] { "Person_PersonId" });
            DropTable("dbo.PrimaryAddresses");
            DropTable("dbo.PhoneNumbers");
            DropTable("dbo.People");
            DropTable("dbo.AlternativeAddresses");
        }
    }
}
