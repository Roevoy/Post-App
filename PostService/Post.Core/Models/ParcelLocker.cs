using POST.Core.Abstractions;

namespace POST.Core.Models
{
    public class ParcelLocker: Destination
    {
        public bool isAvailable { get; set; } = true;
        public ICollection<Shipment> ExpectedShipments { get; set; } = new List<Shipment>();
        public ICollection<Slot> Slots { get; set; } = new List<Slot>();
        public ParcelLocker (Guid AddressId) 
        { 
            this.Id = Guid.NewGuid();
            this.AddressId = AddressId; 
            this.ExceptedShipments = new List<Shipment>();
        }
        public ParcelLocker() { }
    }
}
