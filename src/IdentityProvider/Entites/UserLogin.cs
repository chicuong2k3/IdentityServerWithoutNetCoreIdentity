using System.ComponentModel.DataAnnotations;

namespace IdentityProvider.Entites
{
    public class UserLogin : IConcurrencyAware
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; }
        [Required]
        [MaxLength(100)]
        public string Provider { get; set; }
        [Required]
        [MaxLength(100)]
        public string ProviderIdentityKey { get; set; }
        [ConcurrencyCheck]
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();
    }
}
