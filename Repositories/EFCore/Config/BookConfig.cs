using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Repositories.EFCore.Config
{
    public class BookConfig : BaseConfiguration<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Category)
             .WithMany(x => x.BookList)
             .HasForeignKey(x => x.CategoryId);


            builder.HasOne(x => x.Author)
            .WithMany(x => x.BookList)
            .HasForeignKey(x => x.AuthorId);

        }
    }
}
