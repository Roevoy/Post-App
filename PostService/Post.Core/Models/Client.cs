using POST.Core.Abstractions;

namespace POST.Core.Models
{
    public class Client: Person
    {
        public ICollection<Shipment> SentShipments { get; set; } = new List<Shipment>();
        public ICollection<Shipment> ExpectedShipments { get; set; } = new List<Shipment>();
        public Client(string FirstName, string SecondName, int Age, string Email,
            string Phone, string? ThirdName = null, DateTime? Birthday = null) 
            : base(FirstName, SecondName, Age, Email,
            Phone, ThirdName, Birthday)
        {}
        public Client() { }
    }
}
