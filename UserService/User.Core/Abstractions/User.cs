
namespace User.Core.Abstractions
{
    public abstract class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string? ThirdName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string passwordHash { get; set; }
        public User(string FirstName, string SecondName, string Email, 
            string Phone, DateTime Birthday, string PasswordHash, string? ThirdName)
        {
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.Birthday = Birthday;
            this.Email = Email;
            this.Phone = Phone;
            this.passwordHash = PasswordHash;
        }
        public User() { }
    }
}
