
namespace User.Infrastructure
{
    public class JwtOptions
    {
        public string SecretKey { get; set; } = String.Empty;
        public int ExpiredHours { get; set; }
    }
}
 