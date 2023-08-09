using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Repositories.EFCore.Config
{
    public class RoleClaimsMappingConfiguration : IEntityTypeConfiguration<RoleClaimsMapping>
    {
        public void Configure(EntityTypeBuilder<RoleClaimsMapping> builder)
        {
            builder.HasKey(ur => new { ur.Id, ur.RoleId });

            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.HasOne(ur => ur.Role)
                .WithMany(r => r.RoleClaimsMapping)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

           
        }
    }
}