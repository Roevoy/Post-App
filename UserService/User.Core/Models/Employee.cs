namespace User.Core.Models
{
    public class Employee : Abstractions.User
    {
        public Guid DepartmentId { get; set; } = Guid.Empty;
        private Employee(string FirstName, string SecondName, string Email,
            string Phone, DateTime Birthday, string ThirdName)
            : base(FirstName, SecondName, Email, Phone, Birthday, ThirdName)
        {}
        private Employee() { }
        public static Employee FacroryMethod(string FirstName, string SecondName, string Email, string Phone,
            DateTime Birthday, string? ThirdName = null)
        {
            return new Employee(FirstName, SecondName, Email, Phone, Birthday, ThirdName);
        }
    }
}
