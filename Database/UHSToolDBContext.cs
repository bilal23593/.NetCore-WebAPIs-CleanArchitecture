using Database.Entities.Modules.Login;
using Database.Entities.Modules.Login.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class UHSToolDBContext : DbContext
    {
        public DbSet<UT_Admin_User> UT_Admin_User { get; set; }
        public DbSet<UT_Admin_RoleUser> _UT_Admin_RoleUser { get; set; }
        public DbSet<UT_Admin_Role> _UT_Admin_Role { get; set; }
        public DbSet<UT_Admin_Menu> _UT_Admin_Menu { get; set; }

        public DbSet<SP_Ut_admin_getuserdetails> __SP_Ut_admin_getuserdetails { get; set; }
        public DbSet<SP_Ut_admin_getmenudetails> __SP_Ut_admin_getmenudetails { get; set; }
        public UHSToolDBContext(DbContextOptions<UHSToolDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SP_Ut_admin_getuserdetails>().HasNoKey();
            modelBuilder.Entity<SP_Ut_admin_getmenudetails>().HasNoKey();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UHSToolDBContext).Assembly);
        }


    }
}
