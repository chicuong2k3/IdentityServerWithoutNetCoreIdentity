//using BookStore.Infrastructure.Constants;

//namespace BookStore.Infrastructure.Users
//{
//    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
//    {
//        public void Configure(EntityTypeBuilder<User> builder)
//        {
//            builder.Property(x => x.Id).ValueGeneratedNever();

//            builder.Property(x => x.Email)
//                .IsRequired()
//                .HasMaxLength(UserConstants.EmailMaxLength);

//            builder.HasIndex(x => x.Email).IsUnique();

//            builder.Property(x => x.FirstName)
//                .IsRequired()
//                .HasMaxLength(UserConstants.FirstNameMaxLength);

//            builder.Property(x => x.LastName)
//                .IsRequired()
//                .HasMaxLength(UserConstants.LastNameMaxLength);

//            builder.HasIndex(x => x.IdentityId)
//                .IsUnique();

//        }
//    }
//}
