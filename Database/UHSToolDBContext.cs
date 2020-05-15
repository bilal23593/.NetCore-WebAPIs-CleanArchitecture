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
        public DbSet<UT_Admin_User> _UT_Admin_User { get; set; }
        public DbSet<UT_Admin_RoleUser> _UT_Admin_RoleUser { get; set; }
        public DbSet<UT_Admin_Role> _UT_Admin_Role { get; set; }

        public DbSet<VM_UserRole> _VM_UserRole { get; set; }
        public UHSToolDBContext(DbContextOptions<UHSToolDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VM_UserRole>()
        .HasNoKey();
            modelBuilder.ApplyAllConfigurations<UHSToolDBContext>();
        }


    }
}
