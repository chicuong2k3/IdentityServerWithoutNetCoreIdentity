using System.ComponentModel.DataAnnotations;

namespace IdentityProvider.Entites
{
    public class User : IConcurrencyAware
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Subject { get; set; }

        [MaxLength(100)]
        public string? UserName { get; set; }

        [MaxLength(100)]
        public string? Password { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }
        [MaxLength(100)]
        public string? SecurityCode { get; set; }
        public DateTime SecurityCodeExpirationDate { get; set; }

        [Required]
        public bool Active { get; set; }
        [ConcurrencyCheck]
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();
        public ICollection<UserClaim> Claims { get; set; } = new List<UserClaim>(); 
        public ICollection<UserLogin> Logins { get; set; } = new List<UserLogin>(); 
        public ICollection<UserSecret> Secrets { get; set; } = new List<UserSecret>(); 
    }
}
