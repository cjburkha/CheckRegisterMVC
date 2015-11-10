namespace CheckRegisterMVC.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class locations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Receipt_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Receipts", t => t.Receipt_ID)
                .Index(t => t.Receipt_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "Receipt_ID", "dbo.Receipts");
            DropIndex("dbo.Categories", new[] { "Receipt_ID" });
            DropTable("dbo.Categories");
        }
    }
}
