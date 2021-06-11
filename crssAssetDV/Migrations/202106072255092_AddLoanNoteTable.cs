namespace crssAssetDV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLoanNoteTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoanNotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Loans", "LoanNoteId", c => c.Int());
            CreateIndex("dbo.Loans", "LoanNoteId");
            AddForeignKey("dbo.Loans", "LoanNoteId", "dbo.LoanNotes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "LoanNoteId", "dbo.LoanNotes");
            DropIndex("dbo.Loans", new[] { "LoanNoteId" });
            DropColumn("dbo.Loans", "LoanNoteId");
            DropTable("dbo.LoanNotes");
        }
    }
}
