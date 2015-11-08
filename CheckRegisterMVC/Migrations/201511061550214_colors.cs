namespace CheckRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class colors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Receipts", "Colors", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Receipts", "Colors");
        }
    }
}
