namespace OrdersMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddResourceMeasure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resources", "Measurement_Id", c => c.Long());
            CreateIndex("dbo.Resources", "Measurement_Id");
            AddForeignKey("dbo.Resources", "Measurement_Id", "dbo.Measurements", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resources", "Measurement_Id", "dbo.Measurements");
            DropIndex("dbo.Resources", new[] { "Measurement_Id" });
            DropColumn("dbo.Resources", "Measurement_Id");
        }
    }
}
