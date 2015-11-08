namespace CheckRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Categories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpendingCategoryEntries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category_Description = c.String(),
                        Category_TaxDeductable = c.Boolean(nullable: false),
                        Receipt_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Receipts", t => t.Receipt_ID)
                .Index(t => t.Receipt_ID);
            
            AddColumn("dbo.Receipts", "Approver", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpendingCategoryEntries", "Receipt_ID", "dbo.Receipts");
            DropIndex("dbo.SpendingCategoryEntries", new[] { "Receipt_ID" });
            DropColumn("dbo.Receipts", "Approver");
            DropTable("dbo.SpendingCategoryEntries");
        }
    }
}
