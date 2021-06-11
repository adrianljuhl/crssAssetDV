namespace crssAssetDV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDeviceNoteTable3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeviceNotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Devices", "DeviceNoteId", c => c.Int());
            CreateIndex("dbo.Devices", "DeviceNoteId");
            AddForeignKey("dbo.Devices", "DeviceNoteId", "dbo.DeviceNotes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Devices", "DeviceNoteId", "dbo.DeviceNotes");
            DropIndex("dbo.Devices", new[] { "DeviceNoteId" });
            DropColumn("dbo.Devices", "DeviceNoteId");
            DropTable("dbo.DeviceNotes");
        }
    }
}
