namespace CheckRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameToCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Receipt_ID", "dbo.Receipts");
            RenameTable(name: "dbo.Categories", newName: "Categories");
            DropIndex("dbo.SpendingCategoryEntries", new[] { "Receipt_ID" });
            DropTable("dbo.SpendingCategoryEntries");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.SpendingCategoryEntries", "Receipt_ID");
            AddForeignKey("dbo.Categories", "Receipt_ID", "dbo.Receipts", "ID");
            RenameTable(name: "dbo.Categories", newName: "Categories");
        }
    }
}
