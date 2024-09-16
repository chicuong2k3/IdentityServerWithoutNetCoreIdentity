//namespace BookStore.Infrastructure.Users
//{
//    internal sealed class PermissionConfiguration : IEntityTypeConfiguration<Permission>
//    {
//        public void Configure(EntityTypeBuilder<Permission> builder)
//        {
//            builder.HasKey(x => x.Code);

//            builder.Property(x => x.Code)
//                .HasMaxLength(50);

//            builder.HasData(
//                Permission.GetUser,
//                Permission.ModifyUser,
//                Permission.GetBook,
//                Permission.SearchBooks,
//                Permission.UpdateBookPrice,
//                Permission.GetCart,
//                Permission.AddToCart);

//            builder.HasMany<Role>()
//               .WithMany()
//               .UsingEntity(joinEntity =>
//               {
//                   joinEntity.ToTable("role_permissions");

//                   joinEntity.HasData(
//                    CreateRolePermission(Role.Member, Permission.GetUser),
//                    CreateRolePermission(Role.Member, Permission.ModifyUser),
//                    CreateRolePermission(Role.Member, Permission.GetBook),
//                    CreateRolePermission(Role.Member, Permission.SearchBooks),
//                    CreateRolePermission(Role.Member, Permission.UpdateBookPrice),
//                    CreateRolePermission(Role.Member, Permission.GetCart),
//                    CreateRolePermission(Role.Member, Permission.AddToCart),

//                    CreateRolePermission(Role.Admin, Permission.GetUser),
//                    CreateRolePermission(Role.Admin, Permission.ModifyUser),
//                    CreateRolePermission(Role.Admin, Permission.GetCart),
//                    CreateRolePermission(Role.Admin, Permission.AddToCart));
//               });
//        }

//        private static object CreateRolePermission(Role role, Permission permission)
//        {
//            return new
//            {
//                RoleName = role.Name,
//                PermissionCode = permission.Code
//            };
//        }
//    }
//}
