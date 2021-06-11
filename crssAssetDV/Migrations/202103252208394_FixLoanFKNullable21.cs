namespace crssAssetDV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixLoanFKNullable21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Loans", "LoanType_Id", "dbo.LoanTypes");
            DropIndex("dbo.Loans", new[] { "LoanType_Id" });
            DropColumn("dbo.Loans", "LoanType_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Loans", "LoanType_Id", c => c.Int());
            CreateIndex("dbo.Loans", "LoanType_Id");
            AddForeignKey("dbo.Loans", "LoanType_Id", "dbo.LoanTypes", "Id");
        }
    }
}
