using POST.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POST.Core.Models
{
    public class Employee : Person
    {
        public Guid DepartmentId { get; set; }
        virtual public Department Department { get; set; }
        public Employee(string FirstName, string SecondName, int Age, string Email,
            string Phone, string? ThirdName = null, DateTime? Birthday = null)
            : base(FirstName, SecondName, Age, Email,
            Phone, ThirdName, Birthday)
        {}
        public Employee() { }
    }
}
