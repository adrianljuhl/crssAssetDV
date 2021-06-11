namespace crssAssetDV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLoanNoteTabe2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Loans", "LoanNoteId", "dbo.LoanNotes");
            DropIndex("dbo.Loans", new[] { "LoanNoteId" });
            AddColumn("dbo.LoanNotes", "LoanId", c => c.Int(nullable: false));
            CreateIndex("dbo.LoanNotes", "LoanId");
            AddForeignKey("dbo.LoanNotes", "LoanId", "dbo.Devices", "Id", cascadeDelete: true);
            DropColumn("dbo.Loans", "LoanNoteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Loans", "LoanNoteId", c => c.Int());
            DropForeignKey("dbo.LoanNotes", "LoanId", "dbo.Devices");
            DropIndex("dbo.LoanNotes", new[] { "LoanId" });
            DropColumn("dbo.LoanNotes", "LoanId");
            CreateIndex("dbo.Loans", "LoanNoteId");
            AddForeignKey("dbo.Loans", "LoanNoteId", "dbo.LoanNotes", "Id");
        }
    }
}
