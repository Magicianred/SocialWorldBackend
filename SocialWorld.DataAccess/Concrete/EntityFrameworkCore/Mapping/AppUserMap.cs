using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialWorld.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWorld.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Password).HasMaxLength(100).IsRequired();

            builder.Property(I => I.Email).HasMaxLength(100).IsRequired();
            builder.HasIndex(I => I.Email).IsUnique();

            builder.HasMany(I => I.AppUserRoles).WithOne(I => I.AppUser).HasForeignKey(I => I.AppUserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(I => I.Companies).WithOne(I => I.AppUser).HasForeignKey(I => I.AppUserId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(I => I.Applicants).WithOne(I => I.AppUser).HasForeignKey(I => I.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
