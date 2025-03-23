using User.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Core.Models
{
    public class Employee : User.Core.Abstractions.User
    {
        public Employee(string FirstName, string SecondName, int Age, string Email,
            string Phone, string? ThirdName = null, DateTime? Birthday = null)
            : base(FirstName, SecondName, Age, Email,
            Phone, ThirdName, Birthday)
        {}
        public Employee() { }
    }
}
