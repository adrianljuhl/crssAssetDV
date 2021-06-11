namespace crssAssetDV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixLoanFKNullable23 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Loans", "LoanTypeId");
            AddForeignKey("dbo.Loans", "LoanTypeId", "dbo.LoanTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "LoanTypeId", "dbo.LoanTypes");
            DropIndex("dbo.Loans", new[] { "LoanTypeId" });
        }
    }
}
