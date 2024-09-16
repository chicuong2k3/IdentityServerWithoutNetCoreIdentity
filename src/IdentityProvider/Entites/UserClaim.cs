using System.ComponentModel.DataAnnotations;

namespace IdentityProvider.Entites
{
    public class UserClaim : IConcurrencyAware
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Type { get; set; }
        [Required]
        [MaxLength(250)]
        public string Value { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; }
        [ConcurrencyCheck]
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();
    }
}