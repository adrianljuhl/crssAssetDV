namespace crssAssetDV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixLoanFKNullable22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Loans", "LoanTypeId", c => c.Int());
            DropColumn("dbo.Loans", "LoanId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Loans", "LoanId", c => c.Int());
            DropColumn("dbo.Loans", "LoanTypeId");
        }
    }
}
