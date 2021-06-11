namespace crssAssetDV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixLoanFKNullable : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Loans", "LoanType_Id", c => c.Int());
            AddColumn("dbo.LoanTypes", "Type", c => c.String());
            AlterColumn("dbo.Loans", "LoanId", c => c.Int());
            //CreateIndex("dbo.Loans", "LoanType_Id");
            //AddForeignKey("dbo.Loans", "LoanType_Id", "dbo.LoanTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "LoanType_Id", "dbo.LoanTypes");
            DropIndex("dbo.Loans", new[] { "LoanType_Id" });
            AlterColumn("dbo.Loans", "LoanId", c => c.Int(nullable: false));
            DropColumn("dbo.LoanTypes", "Type");
            DropColumn("dbo.Loans", "LoanType_Id");
        }
    }
}
