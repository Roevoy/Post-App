namespace User.Core.Models
{
    public class Employee : Abstractions.User
    {
        public Guid DepartmentId { get; set; } = Guid.Empty;
        private Employee(string FirstName, string SecondName, string Email,
            string Phone, DateTime Birthday, string PasswordHash,string ThirdName)
            : base(FirstName, SecondName, Email, Phone, Birthday, PasswordHash, ThirdName)
        {}
        private Employee() { }
        public static Employee FacroryMethod(string FirstName, string SecondName, string Email, string Phone,
            DateTime Birthday, string PasswordHash, string? ThirdName = null)
        {
            return new Employee(FirstName, SecondName, Email, Phone, Birthday, PasswordHash, ThirdName);
        }
    }
}
