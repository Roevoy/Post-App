using User.Core.Abstractions;

namespace User.Core.Models
{
    public class Client: User.Core.Abstractions.User
    {
        public Client(string FirstName, string SecondName, int Age, string Email,
            string Phone, string? ThirdName = null, DateTime? Birthday = null) 
            : base(FirstName, SecondName, Age, Email,
            Phone, ThirdName, Birthday)
        {}
        public Client() { }
    }
}
