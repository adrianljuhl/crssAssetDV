namespace crssAssetDV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixDeviceNote2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DeviceNotes", "DeviceId", "dbo.Devices");
            DropIndex("dbo.DeviceNotes", new[] { "DeviceId" });
            AddColumn("dbo.Devices", "DeviceNoteId", c => c.Int(nullable: true));
            AddColumn("dbo.DeviceNotes", "Note", c => c.String());
            CreateIndex("dbo.Devices", "DeviceNoteId");
            AddForeignKey("dbo.Devices", "DeviceNoteId", "dbo.DeviceNotes", "Id", cascadeDelete: false);
            DropColumn("dbo.DeviceNotes", "DeviceId");
            DropColumn("dbo.DeviceNotes", "Notes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DeviceNotes", "Notes", c => c.String());
            AddColumn("dbo.DeviceNotes", "DeviceId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Devices", "DeviceNoteId", "dbo.DeviceNotes");
            DropIndex("dbo.Devices", new[] { "DeviceNoteId" });
            DropColumn("dbo.DeviceNotes", "Note");
            DropColumn("dbo.Devices", "DeviceNoteId");
            CreateIndex("dbo.DeviceNotes", "DeviceId");
            AddForeignKey("dbo.DeviceNotes", "DeviceId", "dbo.Devices", "Id", cascadeDelete: true);
        }
    }
}
