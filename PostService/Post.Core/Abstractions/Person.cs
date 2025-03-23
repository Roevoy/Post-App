
namespace POST.Core.Abstractions
{
    public abstract class Person
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string? ThirdName { get; set; }
        public int Age { get; set; }
        public DateTime? Birthday { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Person(string FirstName, string SecondName, int Age, string Email, 
            string Phone, string? ThirdName = null, DateTime? Birthday = null)
        {
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.Age = Age;
            this.Birthday = Birthday;
            this.Email = Email;
            this.Phone = Phone;
        }
        public Person() { }
    }
}
