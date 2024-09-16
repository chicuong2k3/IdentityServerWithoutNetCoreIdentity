


//using BookStore.Infrastructure.Constants;

//namespace BookStore.Infrastructure.Users
//{
//    internal sealed class UserAddressConfiguration : IEntityTypeConfiguration<UserAddress>
//    {
//        public void Configure(EntityTypeBuilder<UserAddress> builder)
//        {
//            builder.Property(x => x.Id)
//                   .ValueGeneratedNever();

//            builder.ComplexProperty(x => x.Address, buidlerAction =>
//            {
//                buidlerAction.Property(y => y.Town)
//                             .HasMaxLength(AddressConstants.TownMaxLength)
//                             .IsRequired();

//                buidlerAction.Property(y => y.District)
//                             .HasMaxLength(AddressConstants.DistrictMaxLength)
//                             .IsRequired();

//                buidlerAction.Property(y => y.City)
//                             .HasMaxLength(AddressConstants.CityMaxLength)
//                             .IsRequired();

//                buidlerAction.Property(y => y.AddressLine)
//                             .HasMaxLength(AddressConstants.AddressLineMaxLength)
//                             .IsRequired();
//            });
//        }
//    }
//}
