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
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(X => X.Id);
            builder.Property(X => X.Id).UseIdentityColumn();

            builder.Property(X => X.Name).HasMaxLength(100).IsRequired();
            builder.Property(X => X.Address).HasMaxLength(300).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(13).IsRequired();
            builder.Property(x => x.Explanation).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x => x.PhotoString).HasMaxLength(500);
            
            builder.HasMany(I => I.Jobs).WithOne(X => X.Company).HasForeignKey(X => X.CompanyId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
