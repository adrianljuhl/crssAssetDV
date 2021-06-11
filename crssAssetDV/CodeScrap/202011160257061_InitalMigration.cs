namespace crssAssetDV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DamagedSelectOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Option = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Model = c.String(),
                        TypeOfDeviceId = c.Int(nullable: true),
                        Edquip = c.String(),
                        Serial = c.String(),
                        RoleDeviceId = c.Int(nullable: true),
                        BuildingLocation = c.String(),
                        Accessories = c.String(),
                        DamagedRefId = c.Int(nullable: true),
                        PurchaseDate = c.DateTime(),
                        WarrantyTo = c.DateTime(),
                        WriteOff = c.Boolean(nullable: true),
                        WriteOffDate = c.DateTime(),
                        AssetChecked = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DamagedSelectOptions", t => t.DamagedRefId, cascadeDelete: false)
                .ForeignKey("dbo.RoleDevices", t => t.RoleDeviceId, cascadeDelete: false)
                .ForeignKey("dbo.TypeOfDevices", t => t.TypeOfDeviceId, cascadeDelete: false)
                .Index(t => t.TypeOfDeviceId)
                .Index(t => t.RoleDeviceId)
                .Index(t => t.DamagedRefId);
            
            CreateTable(
                "dbo.RoleDevices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeOfDevices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeviceNotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeviceId = c.Int(nullable: true),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Devices", t => t.DeviceId, cascadeDelete: false)
                .Index(t => t.DeviceId);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(),
                        ReturnDate = c.DateTime(),
                        PeopleId = c.Int(nullable: true),
                        DeviceId = c.Int(nullable: true),
                        LoanType = c.String(),
                        Classroom = c.String(),
                        SpecialNote = c.String(),
                        RepairNote = c.String(),
                        SuppliedCable = c.Boolean(nullable: true),
                        SuppliedCover = c.Boolean(nullable: true),
                        SuppliedPowerBlock = c.Boolean(nullable: true),
                        OampsUpdated = c.Boolean(nullable: true),
                        IntuneUpdated = c.Boolean(nullable: true),
                        EdquipSigned = c.Boolean(nullable: true),
                        Loan_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Devices", t => t.DeviceId, cascadeDelete: false)
                .ForeignKey("dbo.Loans", t => t.Loan_Id)
                .ForeignKey("dbo.People", t => t.PeopleId, cascadeDelete: false)
                .Index(t => t.PeopleId)
                .Index(t => t.DeviceId)
                .Index(t => t.Loan_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MIS = c.String(),
                        FullName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Position = c.String(),
                        OnLeave = c.Boolean(nullable: true),
                        Left = c.Boolean(nullable: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RepairNotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RepairDate = c.DateTime(),
                        DeviceId = c.Int(nullable: true),
                        PeopleId = c.Int(nullable: true),
                        LoanNote = c.String(),
                        LoanId = c.Int(nullable: true),
                        RepairTypeId = c.Int(nullable: true),
                        WarrantyRepair = c.Boolean(nullable: true),
                        RepairCost = c.Decimal(nullable: true, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Devices", t => t.DeviceId, cascadeDelete: false)
                .ForeignKey("dbo.Loans", t => t.LoanId, cascadeDelete: false)
                .ForeignKey("dbo.People", t => t.PeopleId, cascadeDelete: false)
                .ForeignKey("dbo.RepairTypes", t => t.RepairTypeId, cascadeDelete: false)
                .Index(t => t.DeviceId)
                .Index(t => t.PeopleId)
                .Index(t => t.LoanId)
                .Index(t => t.RepairTypeId);
            
            CreateTable(
                "dbo.RepairTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Repair = c.String(),
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
            DropForeignKey("dbo.RepairNotes", "RepairTypeId", "dbo.RepairTypes");
            DropForeignKey("dbo.RepairNotes", "PeopleId", "dbo.People");
            DropForeignKey("dbo.RepairNotes", "LoanId", "dbo.Loans");
            DropForeignKey("dbo.RepairNotes", "DeviceId", "dbo.Devices");
            DropForeignKey("dbo.Loans", "PeopleId", "dbo.People");
            DropForeignKey("dbo.Loans", "Loan_Id", "dbo.Loans");
            DropForeignKey("dbo.Loans", "DeviceId", "dbo.Devices");
            DropForeignKey("dbo.DeviceNotes", "DeviceId", "dbo.Devices");
            DropForeignKey("dbo.Devices", "TypeOfDeviceId", "dbo.TypeOfDevices");
            DropForeignKey("dbo.Devices", "RoleDeviceId", "dbo.RoleDevices");
            DropForeignKey("dbo.Devices", "DamagedRefId", "dbo.DamagedSelectOptions");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RepairNotes", new[] { "RepairTypeId" });
            DropIndex("dbo.RepairNotes", new[] { "LoanId" });
            DropIndex("dbo.RepairNotes", new[] { "PeopleId" });
            DropIndex("dbo.RepairNotes", new[] { "DeviceId" });
            DropIndex("dbo.Loans", new[] { "Loan_Id" });
            DropIndex("dbo.Loans", new[] { "DeviceId" });
            DropIndex("dbo.Loans", new[] { "PeopleId" });
            DropIndex("dbo.DeviceNotes", new[] { "DeviceId" });
            DropIndex("dbo.Devices", new[] { "DamagedRefId" });
            DropIndex("dbo.Devices", new[] { "RoleDeviceId" });
            DropIndex("dbo.Devices", new[] { "TypeOfDeviceId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RepairTypes");
            DropTable("dbo.RepairNotes");
            DropTable("dbo.People");
            DropTable("dbo.Loans");
            DropTable("dbo.DeviceNotes");
            DropTable("dbo.TypeOfDevices");
            DropTable("dbo.RoleDevices");
            DropTable("dbo.Devices");
            DropTable("dbo.DamagedSelectOptions");
        }
    }
}
