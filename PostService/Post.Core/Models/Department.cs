using POST.Core.Abstractions;

namespace POST.Core.Models
{
    public class Department : Destination
    {
        public int Number { get; set; }
        public ICollection<Shipment> ExpectedShipments { get; set; } = new List<Shipment>();
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<Shipment> SentShipments { get; set; } = new List<Shipment>();
        public Department(int Number, Guid AddressId)
        {
            this.Number = Number;
            this.AddressId = AddressId;
            this.Id = Guid.NewGuid();
            this.ExceptedShipments = new List<Shipment>();
        }
        public Department() { }
    }
}
