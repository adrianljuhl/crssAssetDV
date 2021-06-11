namespace crssAssetDV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeDeviceNotes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Devices", "DeviceNoteId", "dbo.DeviceNotes");
            DropIndex("dbo.Devices", new[] { "DeviceNoteId" });
            DropColumn("dbo.Devices", "DeviceNoteId");
            DropTable("dbo.DeviceNotes");
        }
        
        public override void Down()
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
    }
}
