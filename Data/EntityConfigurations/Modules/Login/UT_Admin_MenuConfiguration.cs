using Database.Entities.Modules.Login;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityConfigurations.Modules.Login
{
    public class UT_Admin_MenuConfiguration : IEntityTypeConfiguration<UT_Admin_Menu>
    {
        public void Configure(EntityTypeBuilder<UT_Admin_Menu> builder)
        {
            builder.ToTable("UT_Admin_Menu");

            builder.HasKey(b => b.pki_menu_id);
            builder.Property(b => b.pki_menu_id).HasColumnName("pki_menu_id");

            builder.Property(b => b.fki_parent_id).HasColumnName("fki_parent_id").IsRequired();

            builder.Property(b => b.vc_menu).HasColumnName("vc_menu").IsRequired();

            builder.Property(b => b.vc_menu_controller).HasColumnName("vc_menu_controller").IsRequired();

            builder.Property(b => b.vc_menu_action).HasColumnName("vc_menu_action").IsRequired();

            builder.Property(b => b.vc_menu_link).HasColumnName("vc_menu_link").IsRequired();

            builder.Property(b => b.vc_menu_icon).HasColumnName("vc_menu_icon").IsRequired();

            builder.Property(b => b.bi_createdby).HasColumnName("bi_createdby").IsRequired();

            builder.Property(b => b.dt_createdon).HasColumnName("dt_createdon").IsRequired();

            builder.Property(b => b.bi_modifiedby).HasColumnName("bi_modifiedby").IsRequired();

            builder.Property(b => b.dt_modifiedon).HasColumnName("dt_modifiedon").IsRequired();

            builder.Property(b => b.b_isdeleted).HasColumnName("b_isdeleted").IsRequired();

        }
    }
}
