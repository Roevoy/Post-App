namespace User.Core.Models
{
    public class Employee : Abstractions.User
    {
        public Guid DepartmentId { get; set; }
        public Employee(string FirstName, string SecondName, int Age, string Email,
            string Phone, string? ThirdName = null, DateTime? Birthday = null)
            : base(FirstName, SecondName, Age, Email,
            Phone, ThirdName, Birthday)
        {}
        public Employee(Guid DepartmentId)
        {
            this.DepartmentId = DepartmentId;
        }
        public Employee() { }
    }
}
