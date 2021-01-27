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
    public class JobMap : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(X => X.Id);
            builder.Property(X => X.Id).UseIdentityColumn();

            builder.Property(X => X.Name).HasMaxLength(100).IsRequired();

            builder.Property(x => x.Explanation).HasMaxLength(300).IsRequired();
            builder.Property(x => x.PhotoString).HasMaxLength(500);

            builder.HasMany(X => X.Applicants).WithOne(X => X.Job).HasForeignKey(X => X.JobId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
