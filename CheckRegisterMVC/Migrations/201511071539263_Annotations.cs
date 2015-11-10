namespace CheckRegisterMVC.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Annotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Receipts", "StoreName", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Receipts", "Colors");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Receipts", "Colors", c => c.String());
            AlterColumn("dbo.Receipts", "StoreName", c => c.String());
        }
    }
}
