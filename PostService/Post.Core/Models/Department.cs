using POST.Core.Abstractions;

namespace POST.Core.Models
{
    public class Department : Destination
    {
        public int Number { get; set; }
        public List<Guid> Employees { get; set; } = new List<Guid>();
        public ICollection<Shipment> SentShipments { get; set; } = new List<Shipment>();
        public Department(int Number, Guid AddressId)
        {
            this.Id = Guid.NewGuid();
            this.Number = Number;
            this.AddressId = AddressId;
            this.ExceptedShipments = new List<Shipment>();
        }
        public Department() { }
    }
}
