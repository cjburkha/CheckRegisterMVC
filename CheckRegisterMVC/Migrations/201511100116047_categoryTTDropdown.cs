namespace CheckRegisterMVC.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class categoryTTDropdown : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryOptions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ordinal = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TransactionTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ordinal = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TransactionTypes");
            DropTable("dbo.CategoryOptions");
        }
    }
}
