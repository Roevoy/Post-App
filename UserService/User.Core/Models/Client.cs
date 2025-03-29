
namespace User.Core.Models
{
    public class Client: User.Core.Abstractions.User
    {
        private Client(string FirstName, string SecondName, string Email,
            string Phone, DateTime Birthday, string ThirdName) 
            : base(FirstName, SecondName, Email,
            Phone, Birthday, ThirdName)
        {}
        private Client() { }
        public static Client FacroryMethod(string FirstName, string SecondName, string Email, string Phone,
            DateTime Birthday, string? ThirdName = null)
        {
            return new Client(FirstName, SecondName, Email, Phone, Birthday, ThirdName);
        }
    }
}
