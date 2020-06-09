using Database.Entities.Modules.Login;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityConfigurations.Modules.Login
{
    public class LoginConfiguration : IEntityTypeConfiguration<UT_Admin_User>
    {
        public void Configure(EntityTypeBuilder<UT_Admin_User> builder)
        {
            builder.ToTable("UT_Admin_User");

            builder.HasKey(b => b.pki_user_id);
            builder.Property(b => b.pki_user_id).HasColumnName("pki_user_id");

            builder.Property(b => b.vc_username).HasColumnName("vc_username").HasMaxLength(50).IsRequired();

            builder.Property(b => b.vc_password).HasColumnName("vc_password").HasMaxLength(10000).IsRequired();

            builder.Property(b => b.vc_name).HasColumnName("vc_name").HasMaxLength(500).IsRequired();

            builder.Property(b => b.vc_email).HasColumnName("vc_email").HasMaxLength(500).IsRequired();

            builder.Property(b => b.b_isreset).HasColumnName("b_isreset").IsRequired();

            builder.Property(b => b.bi_createdby).HasColumnName("bi_createdby").IsRequired();

            builder.Property(b => b.dt_createdon).HasColumnName("dt_createdon").IsRequired();

            builder.Property(b => b.bi_modifiedby).HasColumnName("bi_modifiedby").IsRequired();

            builder.Property(b => b.dt_modifiedon).HasColumnName("dt_modifiedon").IsRequired();

            builder.Property(b => b.b_isdeleted).HasColumnName("b_isdeleted").IsRequired();

        }
    }
}
