using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace crssAssetDV.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<TypeOfDevice> TypeOfDevices { get; set; }
        public DbSet<RoleDevice> RoleDevices { get; set; }
        public DbSet<DamagedSelectOption> DamagedSelectOptions { get; set; }
        //public DbSet<DeviceNote> DeviceNotes { get; set; }
        public DbSet<People> Peoples { get; set; }
        public DbSet<LoanType> LoanTypes { get; set; }



        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public System.Data.Entity.DbSet<crssAssetDV.Models.People> People { get; set; }

        public System.Data.Entity.DbSet<crssAssetDV.Models.RepairNote> RepairNotes { get; set; }

        public System.Data.Entity.DbSet<crssAssetDV.Models.RepairType> RepairTypes { get; set; }

        public System.Data.Entity.DbSet<crssAssetDV.Models.DeviceNote> DeviceNotes { get; set; }

        public System.Data.Entity.DbSet<crssAssetDV.Models.LoanNote> LoanNotes { get; set; }

        //public System.Data.Entity.DbSet<crssAssetDV.Models.LoanType> LoanTypes { get; set; }

        //public System.Data.Entity.DbSet<crssAssetDV.Models.DevicesViewModel> DevicesViewModels { get; set; }
    }
}