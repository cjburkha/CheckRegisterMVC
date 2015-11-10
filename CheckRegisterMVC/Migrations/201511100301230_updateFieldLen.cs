namespace CheckRegisterMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateFieldLen : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Receipts", "AccountNumber", c => c.String(maxLength: 30));
            AlterColumn("dbo.Receipts", "Approver", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Receipts", "Approver", c => c.String());
            AlterColumn("dbo.Receipts", "AccountNumber", c => c.String());
        }
    }
}
