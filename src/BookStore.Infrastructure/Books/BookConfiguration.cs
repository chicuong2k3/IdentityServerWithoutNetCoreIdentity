using BookStore.Infrastructure.Constants;

namespace BookStore.Infrastructure.Books;

internal sealed class BookBookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedNever();

        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(BookConstants.TitleMaxLength);

        builder.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(BookConstants.DescriptionMaxLength);

        builder.Property(e => e.Author)
            .IsRequired()
            .HasMaxLength(BookConstants.AuthorMaxLength);

        builder.Property(e => e.Price)
            .HasPrecision(BookConstants.PricePrecision, BookConstants.PriceScale);
    }
}
