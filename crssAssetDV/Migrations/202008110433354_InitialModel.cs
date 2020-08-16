namespace crssAssetDV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true),
                        Brand = c.String(),
                        Model = c.String(),
                        Description = c.String(),
                        Edquip = c.String(),
                        Serial = c.String(),
                        SpecialisedDevice = c.String(),
                        BuildingLocation = c.String(),
                        HasPowerSupply = c.String(),
                        HasPowerCable = c.String(),
                        HasCover = c.String(),
                        Accessories = c.String(),
                        Damaged = c.String(),
                        WriteOff = c.Boolean(nullable: false),
                        DeviceNotes_Id = c.Decimal(precision: 18, scale: 0),
                        TypeOfDevice_Id = c.Decimal(precision: 18, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeviceNotes", t => t.DeviceNotes_Id)
                .ForeignKey("dbo.TypeOfDevices", t => t.TypeOfDevice_Id)
                .Index(t => t.DeviceNotes_Id)
                .Index(t => t.TypeOfDevice_Id);
            
            CreateTable(
                "dbo.DeviceNotes",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 18, scale: 0),
                        DeviceNote = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeOfDevices",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoanType = c.String(),
                        Location = c.String(),
                        SuppliedPowerBlock = c.String(),
                        SuppliedCable = c.String(),
                        SuppliedCover = c.String(),
                        oampsUpdated = c.String(),
                        intuneUpdated = c.String(),
                        edquipSigned = c.String(),
                        Approvers_Id = c.Int(),
                        Devices_Id = c.Decimal(precision: 18, scale: 0),
                        People_Id = c.Decimal(precision: 18, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Approvers", t => t.Approvers_Id)
                .ForeignKey("dbo.Devices", t => t.Devices_Id)
                .ForeignKey("dbo.People", t => t.People_Id)
                .Index(t => t.Approvers_Id)
                .Index(t => t.Devices_Id)
                .Index(t => t.People_Id);
            
            CreateTable(
                "dbo.Approvers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        People_Id = c.Decimal(precision: 18, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.People_Id)
                .Index(t => t.People_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 18, scale: 0),
                        Staff = c.Boolean(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Address3 = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Loans", "People_Id", "dbo.People");
            DropForeignKey("dbo.Loans", "Devices_Id", "dbo.Devices");
            DropForeignKey("dbo.Loans", "Approvers_Id", "dbo.Approvers");
            DropForeignKey("dbo.Approvers", "People_Id", "dbo.People");
            DropForeignKey("dbo.Devices", "TypeOfDevice_Id", "dbo.TypeOfDevices");
            DropForeignKey("dbo.Devices", "DeviceNotes_Id", "dbo.DeviceNotes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Approvers", new[] { "People_Id" });
            DropIndex("dbo.Loans", new[] { "People_Id" });
            DropIndex("dbo.Loans", new[] { "Devices_Id" });
            DropIndex("dbo.Loans", new[] { "Approvers_Id" });
            DropIndex("dbo.Devices", new[] { "TypeOfDevice_Id" });
            DropIndex("dbo.Devices", new[] { "DeviceNotes_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.People");
            DropTable("dbo.Approvers");
            DropTable("dbo.Loans");
            DropTable("dbo.TypeOfDevices");
            DropTable("dbo.DeviceNotes");
            DropTable("dbo.Devices");
        }
    }
}
