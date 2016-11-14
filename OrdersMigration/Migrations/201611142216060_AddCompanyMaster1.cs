namespace OrdersMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMaster1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyMasters",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Ext_Id = c.String(maxLength: 50),
                        Code = c.String(),
                        Name = c.String(),
                        Created = c.DateTime(nullable: false),
                        UserCreated = c.Long(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        UserUpdated = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Companies", "CompanyMaster_Id", c => c.Long());
            CreateIndex("dbo.Companies", "CompanyMaster_Id");
            AddForeignKey("dbo.Companies", "CompanyMaster_Id", "dbo.CompanyMasters", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "CompanyMaster_Id", "dbo.CompanyMasters");
            DropIndex("dbo.Companies", new[] { "CompanyMaster_Id" });
            DropColumn("dbo.Companies", "CompanyMaster_Id");
            DropTable("dbo.CompanyMasters");
        }
    }
}
