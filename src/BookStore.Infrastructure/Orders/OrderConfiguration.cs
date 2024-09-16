using BookStore.Domain.Orders;
using BookStore.Infrastructure.Constants;

namespace BookStore.Infrastructure.Orders
{
    internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.ComplexProperty(o => o.ShippingAddress, buildAction =>
            {
                buildAction.Property(x => x.Town)
                            .HasMaxLength(AddressConstants.TownMaxLength)
                            .IsRequired();

                buildAction.Property(x => x.District)
                            .HasMaxLength(AddressConstants.DistrictMaxLength)
                            .IsRequired();

                buildAction.Property(x => x.City)
                            .HasMaxLength(AddressConstants.CityMaxLength)
                            .IsRequired();

                buildAction.Property(x => x.AddressLine)
                            .HasMaxLength(AddressConstants.CityMaxLength)
                            .IsRequired();
            });
        }
    }
}
