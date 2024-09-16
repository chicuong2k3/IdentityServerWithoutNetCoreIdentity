using BookStore.Domain.Orders;

namespace BookStore.Infrastructure.Orders
{
    internal sealed class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.Description)
                .HasMaxLength(100);
        }
    }
}
