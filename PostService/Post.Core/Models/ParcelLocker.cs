using POST.Core.Abstractions;

namespace POST.Core.Models
{
    public class ParcelLocker: Destination
    {
        public bool IsAvailable { get; set; } = true;
        public Guid RecipientId { get; set; }
        public ICollection<Slot> Slots { get; set; }
        public ParcelLocker (Guid AddressId, ICollection<Slot> slots) 
        { 
            this.Id = Guid.NewGuid();
            this.AddressId = AddressId; 
            this.ExceptedShipments = new List<Shipment>();
        }
        public ParcelLocker() { }
    }
}
