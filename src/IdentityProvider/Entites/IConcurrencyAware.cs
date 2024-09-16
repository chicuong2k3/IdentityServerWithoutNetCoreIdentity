namespace IdentityProvider.Entites
{
    public interface IConcurrencyAware
    {
        string ConcurrencyStamp { get; set; }
    }
}
