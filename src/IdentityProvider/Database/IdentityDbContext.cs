using IdentityProvider.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityProvider.Database
{
    public class IdentityDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<UserSecret> UserSecrets { get; set; }
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasIndex(u => u.Subject).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();

            var passwordHasher = new PasswordHasher<User>();
            var user1 = new User()
            {
                Id = new Guid("f5f4b3b3-3b6d-4b1e-8b3d-3b6d4b1e8b3d"),
                Subject = Guid.NewGuid().ToString(),
                UserName = "cuong",
                Email = "chicuong123@gmail.com",
                Active = true
            };
            user1.Password = passwordHasher.HashPassword(user1, "cuong");

            var user2 = new User()
            {
                Id = new Guid("f5f4b3b3-3b6d-4b1e-4a3d-3b6d4b1e2a6a"),
                Subject = Guid.NewGuid().ToString(),
                UserName = "dung",
                Email = "tandung@gmail.com",
                Active = true
            };
            user2.Password = passwordHasher.HashPassword(user2, "dung");

            modelBuilder.Entity<User>().HasData(
                user1, user2
            );

            modelBuilder.Entity<UserClaim>().HasData(
                new UserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = user1.Id,
                    Type = "given_name",
                    Value = "Cường"
                },
                 new UserClaim()
                 {
                     Id = Guid.NewGuid(),
                     UserId = user1.Id,
                     Type = "family_name",
                     Value = "Nguyễn"
                 },
                new UserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = user1.Id,
                    Type = "role",
                    Value = "Admin"
                },
                new UserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = user1.Id,
                    Type = "country",
                    Value = "cn"
                },
                
                new UserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = user2.Id,
                    Type = "given_name",
                    Value = "Dũng"
                },
                new UserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = user2.Id,
                    Type = "family_name",
                    Value = "Tấn"
                },
                new UserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = user2.Id,
                    Type = "role",
                    Value = "Customer"
                },
                new UserClaim()
                {
                    Id = Guid.NewGuid(),
                    UserId = user2.Id,
                    Type = "country",
                    Value = "vn"
                }
            );
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var updatedEntries = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Modified)
                .OfType<IConcurrencyAware>();

            foreach (var updatedEntry in updatedEntries)
            {
                updatedEntry.ConcurrencyStamp = Guid.NewGuid().ToString();
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
