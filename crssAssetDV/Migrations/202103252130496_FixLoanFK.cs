namespace crssAssetDV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixLoanFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Loans", "LoanId", "dbo.LoanTypes");
            DropIndex("dbo.Loans", new[] { "LoanId" });
            DropColumn("dbo.LoanTypes", "LoanTypes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LoanTypes", "LoanTypes", c => c.String());
            CreateIndex("dbo.Loans", "LoanId");
            AddForeignKey("dbo.Loans", "LoanId", "dbo.LoanTypes", "Id", cascadeDelete: true);
        }
    }
}
