namespace CheckRegisterMVC.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CheckRegisterMVC.Models.ReceiptContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CheckRegisterMVC.Models.ReceiptContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //ID = c.Int(nullable: false, identity: true),
            //            Ordinal = c.Int(nullable: false),
            //            Description = c.String(),
            //var rc = new Data.ReceiptRepository();
            //var allreceipts = rc.GetReceipts();
            //context.Receipts.AddOrUpdate(i => i.ID,
            //    allreceipts[0], allreceipts[1]
            //);
            context.CategoryOptions.AddOrUpdate(co => co.ID,
                new Models.CategoryOption { ID = 1, Ordinal = 1, Description = "Household"},
                new Models.CategoryOption { ID = 2, Ordinal = 2, Description = "Entertainment" },
                new Models.CategoryOption { ID = 3, Ordinal = 3, Description = "Misc." }
            );

            context.TransactionTypes.AddOrUpdate(tt => tt.ID,
                new Models.TransactionType { ID = 1, Ordinal = 1, Description = "Deposit" },
                new Models.TransactionType { ID = 2, Ordinal = 2, Description = "Check" },
                new Models.TransactionType { ID = 3, Ordinal = 3, Description = "Withdrawl" }
            );


        }
    }
}
