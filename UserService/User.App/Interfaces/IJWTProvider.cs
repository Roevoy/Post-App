namespace User.App.Interfaces
{
    public interface IJWTProvider
    {
        string GenerateToken(Core.Abstractions.User user);
    }
}