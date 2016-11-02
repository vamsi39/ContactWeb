namespace ContactWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()    //Up method - create a table
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhonePrimary = c.String(),
                        PhoneSecondary = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        StreetAddress1 = c.String(),
                        StreetAddress2 = c.String(),
                        City = c.String(),
                        County = c.String(),
                        PostCode = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()    // Down method - drop a table
        {
            DropTable("dbo.Contacts");
        }
    }
}
