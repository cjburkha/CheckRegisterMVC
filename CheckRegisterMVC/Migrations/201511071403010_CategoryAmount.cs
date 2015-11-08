namespace CheckRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryAmount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Amount");
        }
    }
}
