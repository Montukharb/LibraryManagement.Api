using LibraryManagement.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace LibraryManagement.EntityConfiguration
{
    public class BookCofiguration : IEntityTypeConfiguration<Books>
    {
        public void Configure(EntityTypeBuilder<Books> builder)
        {

            builder.Property(x => x.Title).HasMaxLength(80);
            builder.HasIndex(x => x.PublisherId).IsUnique();
            builder.Property(x => x.PublisherName).HasMaxLength(100);

            builder.HasData(
                new Books
                {
                    Name = "Lucent",
                    Price = 300,
                    BookId = 1,
                    PublisherId = 89521,
                    Title = "Gk Book",
                    PublisherName = "GovtPublicationHouse",
                }
                );
        }
    }
}
