using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Config
{
    public class RentConfig : BaseConfiguration<Rent>
    {
        public override void Configure(EntityTypeBuilder<Rent> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.User)
            .WithMany(x => x.RentList)
            .HasForeignKey(x => x.UserId);


            builder.HasOne(x => x.Book)
            .WithMany(x => x.RentList)
            .HasForeignKey(x => x.BookId);
        }
    }
}
